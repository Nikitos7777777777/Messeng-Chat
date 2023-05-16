﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Wpf6
{
    static class SoketExiceon
    {
        public static bool IsConnected(this Socket socket)
        {
            try
            {
                return !(socket.Poll(1, SelectMode.SelectRead) && socket.Available == 0);
            }
            catch (SocketException) { return false; }
        }

        public static char[] Namechar(List<SocketModel> names)
        {
            char[] chars = new char[10];
           
            try
            {               
                chars = names.SelectMany(item => $"/@/ {item.name}").ToArray();
                return chars;
            }
            catch (Exception e )
            {
                MessageBox.Show(e.ToString());
                return chars;
               
            }
           
        }
        public static string Filter(this string str, List<char> charsToRemove)
        {          
            return String.Concat(str.Split(charsToRemove.ToArray()));
        }
        public static string Time() 
        { 
            var time = DateTime.Now.ToString();
            return time;
        }


    }
}
