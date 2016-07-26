using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using System.Collections;
using System.Collections.Specialized;

namespace file_browsing.Models
{
    public class BrFile
    {

         StringCollection log = new StringCollection();
         public int less;
         public int norm;
         public int lot;
        
         public string put;

        

        
        public List<string> directories = new List<string>();
         DriveInfo[] allDrives = DriveInfo.GetDrives();
        
        public  List<string> FunctionDir(){ 
           
            List<string> drivers = new List<string>();
            foreach (var item in allDrives)
                {
                    if (item.IsReady)
                    {
                        drivers.Add(item.ToString());
                    }
                    
                }
            return drivers;
        }

        public  void FunctionNumber(){
            directories.Clear();
           
            DirectoryInfo di = new DirectoryInfo(put);

               
                foreach (var item in di.GetDirectories())
                {
                    directories.Add(item.ToString());
                }

                foreach (var item in di.GetFiles("*"))
                {
                    directories.Add(item.ToString());
                }


                method(di);
            
        }
        public void method(DirectoryInfo dr)
        {
            DirectoryInfo[] dir = null;
            FileInfo[] mas = null;
            try
            {
                mas = dr.GetFiles("*");
            }
            catch (UnauthorizedAccessException e)
            {

                log.Add(e.Message);
            }

            catch (System.IO.DirectoryNotFoundException e)
            {
                log.Add(e.Message);
            }
            catch (System.IO.PathTooLongException e)
            {
                log.Add(e.Message);
            }

            if (mas != null)
            {
                foreach (FileInfo item in mas)
                {
                    if (item.Length * 0.000001 <= 10)
                    {
                        less++;
                    }
                    else if (item.Length * 0.000001 > 10 && item.Length * 0.000001 <= 50)
                    {
                        norm++;
                    }
                    else if (item.Length * 0.000001 >= 100)
                    {
                        lot++;
                    }
                }
                dir = dr.GetDirectories();
                foreach (var item in dir)
                {
                    method(item);
                }
            }
        }



    }
}