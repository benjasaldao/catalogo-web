using System;
using System.IO;
using System.Windows.Forms;

namespace Utilities
{
    public class BusinessUtilities
    {
        public static string saveImg(string oldPath)
        {
            string newPath;
            createImageFolder();

            try
            {
                string imgExt = Path.GetExtension(oldPath);

                DateTime date = DateTime.Now;
                string imgName = date.ToString("yyyyMMddHHmmss") + imgExt;

                newPath = Application.StartupPath + @"\productsImg\" + imgName;

                File.Copy(oldPath, newPath);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return newPath;
        }

        public static void deleteImg(string path)
        {
            try
            {
                File.Delete(path);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private static void createImageFolder()
        {
            string imgFolderPath = Application.StartupPath + @"\productsImg";

            try
            {
                if (!Directory.Exists(imgFolderPath))
                {
                    Directory.CreateDirectory(imgFolderPath);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
