using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FTP
{
    public class FileInfomation
    {
        /// <summary>
        /// 判断该目录信息，是否为文件夹
        /// 文件夹，文件处理方式不同
        /// </summary>
        public bool IsFolder;

        /// <summary>
        /// 文件大小
        /// </summary>
        public long Size { get; }
        /// <summary>
        /// 文件名称
        /// </summary>
        public string FileName { get; }
        /// <summary>
        /// 文件/文件夹 最后修改时间， 根据LIST传回的格式，一共有两类
        /// </summary>
        public string ModifiedAt { get; }

        //构造函数，获取文件基本信息
        //LIST 返回的格式，有两种类型
        //1. -rw-r--r-- 1 ftp ftp             12 Jul 28 16:08 测试中文文件2.txt
        //   file/folder 权限 拥有者 组   文件大小 月  日 时间  文件名称
        //2. drwxr-xr-x 1 ftp ftp              0 Apr 09  2019 testFolder
        //   file/folder 权限 拥有者 组  文件夹大小 月 日 年份  文件夹名称
        //本程序中主要使用属性： 文件/文件夹标识 大小 最后修改时间 名称
        public FileInfomation(string line)
        {
            int nameIndex = 8;
            int columnCount = 9;

            string[] s = new string[columnCount];

            int i = 0;
            int flag = 1;
            int p = 0;
            for (p = 0; p < line.Length; p++)
                if (line[p] != ' ')
                    break;

            for (; p < line.Length; p++)
            {
                // 文件名部分无视空格半段
                if (i == nameIndex)
                {
                    s[i] += line[p];
                    continue;
                }

                if (flag == 0)
                {
                    if (line[p] == ' ') continue;

                    flag = 1;
                    i++;
                    s[i] = "" + line[p];
                    continue;
                }

                if (flag == 1)
                {
                    if (line[p] != ' ')
                    {
                        s[i] += line[p];
                        continue;
                    }

                    flag = 0;
                    continue;
                }
            }
            this.IsFolder = (s[0][0] == 'd') ? true : false;
            this.Size = Int64.Parse(s[4]);
            this.ModifiedAt = toDataTime(s[5], s[6], s[7]);
            this.FileName = s[8];
        }

        // 将LIST传回时间信息格式化
        private string toDataTime(string a, string b, string c)
        {
            DateTime curTime;
            string curTimeString;
            if (c.Contains(":")) { curTime = DateTime.Parse("" + DateTime.Now.Year + a + ' ' + b + ' ' + c + ':' + "00"); }
            else { curTime = DateTime.Parse(a + ' ' + b + ' ' + c); }
            curTime = curTime.ToLocalTime();
            curTimeString = curTime.ToString("yyyy/M/d HH:mm");
            return curTimeString;
        }
    }
}
