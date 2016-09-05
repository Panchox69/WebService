using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Drawing;
using System.Drawing.Imaging;
using System.Web.SessionState;
using System.Text;


namespace Vistas.VistasClientes
{
    /// <summary>
    /// Crea un captcha de forma aleatoria, creando una imagen con numeros y letras
    /// </summary>

    public class CaptchaHandler : IHttpHandler, IRequiresSessionState
    {
        public void ProcessRequest(HttpContext context)
        {
                       
            Bitmap NewBitmap = new Bitmap(150, 50, PixelFormat.Format32bppArgb);
            Graphics NewGraphics = Graphics.FromImage(NewBitmap);
            Rectangle NewRectangle = new Rectangle(0, 0, 150, 50);
            NewGraphics.FillRectangle(Brushes.Gray, NewRectangle);
             
            StringBuilder randomText = new StringBuilder();
            string alphabets = "012345679ACEFGHKLMNPRSWXZabcdefghijkhlmnopqrstuvwxyz";
            Random r = new Random();
            for (int j = 0; j <= 5; j++)
            randomText.Append(alphabets[r.Next(alphabets.Length)]);
            String drawCaptchaString = randomText.ToString();
            context.Session["Captcha"] = drawCaptchaString;
            string ses = context.Session["Captcha"].ToString();
            Font drawCaptchaFont = new Font("Segoe Script", 20, FontStyle.Italic);
            SolidBrush drawCaptchaBrush = new SolidBrush(Color.Yellow);
            PointF Point = new PointF(15, 10);
          
            NewGraphics.DrawRectangle(new Pen(Color.White, 0), NewRectangle);
            NewGraphics.DrawString(drawCaptchaString, drawCaptchaFont, drawCaptchaBrush, Point);
            NewBitmap.Save(context.Response.OutputStream, ImageFormat.Jpeg);
            context.Response.ContentType = "image/jpeg";
            context.Response.End();
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
 
    }
}