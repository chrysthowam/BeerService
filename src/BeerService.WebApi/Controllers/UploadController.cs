using BeerService.Domain.Core.Bus;
using BeerService.Domain.Core.Notifications;
using MediatR;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.StaticFiles;
using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Net.Http.Headers;
using System.Threading.Tasks;

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

		[HttpGet, DisableRequestSizeLimit]
		[Route("download")]
		public async Task<IActionResult> UploadFile([FromQuery] string arquivo)
		{
			try
			{
				var folderName = Path.Combine("Resources", "Images");
				var path = Path.Combine(Directory.GetCurrentDirectory(), folderName);

				var filePath = Path.Combine(path, arquivo);

				var memory = new MemoryStream();

				using (var stream = new FileStream(filePath, FileMode.Open))
				{
					await stream.CopyToAsync(memory);

					Bitmap image = new Bitmap(1, 1);
					image.Save(memory, ImageFormat.Jpeg);

					byte[] byteImage = memory.ToArray();
					return Response(byteImage);
				}

			}
			catch (Exception ex)
			{
				NotifyError("Business", ex.Message);
				return Response();
			}
		}
	}
}