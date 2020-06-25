using BeerService.Domain.Core.Bus;
using BeerService.Domain.Core.Notifications;
using MediatR;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System;
using System.IO;
using System.Net.Http.Headers;

namespace BeerService.WebApi.Controllers
{
    public class FileController : MainController
	{
		private IWebHostEnvironment _hostingEnvironment;

		public FileController(INotificationHandler<Notification> notifications, 
            IMediatorHandler mediator, IWebHostEnvironment hostingEnvironment) : base(notifications, mediator)
		{
			_hostingEnvironment = hostingEnvironment;
		}

		[HttpPost, DisableRequestSizeLimit]
		[Route("upload")]
		public IActionResult UploadFile()
		{
			try
			{
				var file = Request.Form.Files[0];
				var folderName = Path.Combine("Resources", "Images");
				var pathToSave = Path.Combine(Directory.GetCurrentDirectory(), folderName);
				if (!Directory.Exists(pathToSave))
				{
					Directory.CreateDirectory(pathToSave);
				}
				if (file.Length > 0)
				{
					var fileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');
					var fullPath = Path.Combine(pathToSave, fileName);
					var dbPath = Path.Combine(folderName, fileName);

					using (var stream = new FileStream(fullPath, FileMode.Create))
					{
						file.CopyTo(stream);
					}

					return Ok(new { dbPath });
				}
				return Response();
			}
			catch (Exception ex)
			{
				NotifyError("Business", ex.Message);
				return Response();
			}
		}
	}
}