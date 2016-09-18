using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CustomLibrary
{
     public static class Extensions
    {
        // all params are optional

        public static DateTime? ToDate(this object obj)
        {
            try
            {
                if (obj == null)
                {
                    return null;
                }
                else
                {
                    return DateTime.Parse(obj.ToString());
                }
            }
            catch (Exception)
            {
                return null;
            }
        }
        public static byte ToByte(this object obj)
        {
            try
            {                            
                if (obj == null)
                {
                    return 0;
                }
                else
                {
                    return byte.Parse(obj.ToString());
                }
            }
            catch (Exception)
            {
                return 0;
            }
        }

        public static bool? ToBool(this object obj)
        {
            try
            {
                if (obj == null)
                {
                    return null;
                }
                else
                {
                    return bool.Parse(obj.ToString());
                }
            }
            catch (Exception)
            {
                return null;
            }
        }

        //IsNull returns true if object is null and false if the object is not null
        public static bool IsNull(this object obj)
        {
            try
            {
                if (obj == null)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }


        public static int ToInt(this object obj)
        {
            try
            {
                if (obj == null)
                {
                    return 0;
                }
                else
                {
                    return int.Parse(obj.ToString());
                }
            }
            catch (Exception)
            {
                return 0;
            }
        }

        public static long ToLong(this object obj)
        {
            try
            {
                if (obj == null)
                {
                    return 0;
                }
                else
                {
                    return long.Parse(obj.ToString());
                }
            }
            catch (Exception)
            {
                return 0;
            }
        }

        public static decimal ToDecimal(this object obj)
        {
            try
            {
                if (obj == null)
                {
                    return 0;
                }
                else
                {                    
                    return Math.Round(decimal.Parse(obj.ToString()),2);
                }
            }
            catch (Exception)
            {
                return 0;
            }
        }

        public static double ToDouble(this object obj)
        {
            try
            {
                if (obj == null)
                {
                    return 0;
                }
                else
                {
                    return Math.Round(double.Parse(obj.ToString()), 2);
                }
            }
            catch (Exception)
            {
                return 0;
            }
        }

        public static byte ToByte(this TextBox txt)
        {
            try
            {
                if (txt.Text.IsEmpty() || !txt.Text.IsNumeric())
                {
                    return 0;
                }
                else
                {
                    return byte.Parse(txt.Text);
                }
            }
            catch (Exception)
            {
                return 0;
            }
        }

        public static int ToInt(this TextBox txt)
        {
            try
            {
                if (txt.Text.IsEmpty() || !txt.Text.IsNumeric())
                {
                    return 0;
                }
                else
                {
                    return int.Parse(txt.Text);
                }
            }
            catch (Exception)
            {
                return 0;
            }
        }

        public static long ToLong(this TextBox txt)
        {
            try
            {
                if (txt.Text.IsEmpty() || !txt.Text.IsNumeric())
                {
                    return 0;
                }
                else
                {
                    return long.Parse(txt.Text);
                }
            }
            catch (Exception)
            {
                return 0;
            }
        }

        public static decimal ToDecimal(this TextBox txt)
        {
            try
            {
                if (txt.Text.IsEmpty() || !txt.Text.IsNumeric())
                {
                    return 0;
                }
                else
                {
                    return Math.Round(decimal.Parse(txt.Text),2);
                }
            }
            catch (Exception)
            {
                return 0;
            }
        }

        public static double ToDouble(this TextBox txt)
        {
            try
            {
                if (txt.Text.IsEmpty() || !txt.Text.IsNumeric())
                {
                    return 0;
                }
                else
                {
                    return double.Parse(txt.Text);
                }
            }
            catch (Exception)
            {
                return 0;
            }
        }

        public static float ToFloat(this TextBox txt)
        {
            try
            {
                if (txt.Text.IsEmpty() || !txt.Text.IsNumeric())
                {
                    return 0;
                }
                else
                {
                    return float.Parse(txt.Text);
                }
            }
            catch (Exception)
            {
                return 0;
            }
        }

        public static bool IsNumeric(this string str)
        {
            if (str.IsEmpty())
                return false;

            foreach (char c in str)
            {
                if (!char.IsDigit(c) && c != '.' && c != ',' && c != '-')
                {
                    return false;
                }
            }
            return true;
        }

        public static bool IsEmpty(this string str)
        {
            if (string.IsNullOrEmpty(str) || string.IsNullOrWhiteSpace(str))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static bool IsNumeric(this TextBox txt)
        {
            if (txt.IsEmpty())
                return false;
            foreach (char c in txt.Text)
            {
                if (!char.IsDigit(c) && c != '.' && c != ',')
                {
                    return false;
                }
            }

            return true;
        }

        public static bool IsEmpty(this TextBox txt)
        {
            if (string.IsNullOrEmpty(txt.Text) || string.IsNullOrWhiteSpace(txt.Text))
            {
                return true;
            }
            else
            {
                return false;
            }
        }        

        public static bool IsEmpty(this object txt)
        {
            if (txt == null || string.IsNullOrWhiteSpace(txt.ToString()) || string.IsNullOrEmpty(txt.ToString()))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        //Extension method for IsUniqueKeyViolation
        public static bool IsUniqueKeyViolation(this SqlException ex)
        {
            return ex.Errors.Cast<SqlError>().Any(e => e.Class == 14 && (e.Number == 2601 || e.Number == 2627));
        }

        public static bool IsEmpty(this ComboBox cmb)
        {
            if (cmb.SelectedValue.IsNull() || cmb.SelectedIndex == -1 || cmb.Text.IsEmpty())
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        
    }


}

