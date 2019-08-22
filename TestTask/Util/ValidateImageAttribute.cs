using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Reflection;
using System.Web;

namespace TestTask.Util
{
    public class ValidateImageAttribute: RequiredAttribute
    {
        private List<ImageFormat> formats;
        public ValidateImageAttribute(string formats, string ErrorMessage = "")
        {
            if (string.IsNullOrEmpty(formats))
            {
                throw new ArgumentNullException("Image formats can`t be empty");
            }
            this.ErrorMessage = ErrorMessage;
            this.formats = formats.Split(new[] { '|' }).Select(strFormat => ParseImageFormat(strFormat)).ToList();
        }

        public override bool IsValid(object value)
        {
            var file = value as HttpPostedFileWrapper;
            if (file == null)
            {
                return true;
            }
            if (file.ContentLength > 2 * 1024 * 1024)
            {
                return false;
            }
            try
            {
                using(var img = Image.FromStream(file.InputStream))
                {
                    foreach(var format in this.formats)
                    {
                        var f = img.RawFormat;
                        if (img.RawFormat.Equals(format))
                        {
                            return true;
                        }
                    }
                }
            } catch (Exception e)
            {
                return false;
            }
            return false;
        }

        private static ImageFormat ParseImageFormat(string str)
        {
            return (ImageFormat)typeof(ImageFormat)
                    .GetProperty(str, BindingFlags.Public | BindingFlags.Static | BindingFlags.IgnoreCase)
                    .GetValue(null);
        }
    }
}