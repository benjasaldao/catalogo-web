using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Utilities
{
    public static class PresentationUtilities
    {
        public static void loadImage(string imageUrl, PictureBox pbo)
        {
            try
            {
                pbo.Load(imageUrl);
            }
            catch (Exception)
            {
                pbo.Load("https://efectocolibri.com/wp-content/uploads/2021/01/placeholder.png");
            }
        }

        public static bool onlyNumbers(string text)
        {
            foreach (char caracter in text)
            {
                if (!(char.IsNumber(caracter)))
                {
                    return false;
                }
            }
            return true;
        }

        public static bool isProductCode(string code)
        {
            for (int i = 0; i < 3; i++)
            {
                if(i == 0 && char.IsNumber(code[0]))
                {
                    return false;
                } else
                {
                    if (!char.IsNumber(code[i]) && i != 0)
                    {
                        return false;
                    }
                }
            }

            return true;
        }
    }
}
