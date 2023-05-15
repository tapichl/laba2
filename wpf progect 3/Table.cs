using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace wpf_progect_3
{
    internal class Table
    {
        public int Size { get; set; }
        public string Name { get; set; }
        public string Path { get; set; }
        public string ColumnsPath { get; set; }
        public List<string> Columns { get; set; }

        public Table(string name, string[] columnNames, string dir = "Tables")
        {

            Name = name;

            Path = $"Table/{dir}/{name}.txt";

            ColumnsPath = $"Table/ColumnsName/Columns{name}.txt";

            Columns = new List<string>();

            if (!File.Exists(Path))
            {
                StreamWriter sw = new StreamWriter(Path);
                sw.Close();
            }

            if (File.Exists(ColumnsPath))
            {
                string[] filee = File.ReadAllLines(ColumnsPath);
                if (filee.Length != 0)
                {
                    string[] ColumnsFile = File.ReadAllLines(ColumnsPath);

                    StreamWriter sw = new StreamWriter(ColumnsPath, true);
                    bool is_here = false;

                    for (int i = 0; i < columnNames.Length; i++)
                    {
                        for (int j = 0; j < ColumnsFile.Length; j++)
                        {
                            is_here = columnNames[i] == ColumnsFile[j];
                            if (is_here == true)
                                break;
                        }
                        if (is_here == false)
                            sw.Write("\n" + columnNames[i]);
                    }

                    sw.Close();
                    ColumnsFile = File.ReadAllLines(ColumnsPath);

                    for (int i = 0; i < ColumnsFile.Length; i++)
                        Columns.Add(ColumnsFile[i]);
                }
                else
                {
                    StreamWriter sw = new StreamWriter(ColumnsPath);
                    sw.Write(columnNames[0]);
                    Columns.Add(columnNames[0]);

                    for (int i = 1; i < columnNames.Length; i++)
                    {
                        Columns.Add(columnNames[i]);
                        sw.Write("\n" + columnNames[i]);

                    }
                    sw.Close();
                }
            }
            else
            {
                StreamWriter sw = new StreamWriter(ColumnsPath);
                sw.Write(columnNames[0]);
                Columns.Add(columnNames[0]);

                for (int i = 1; i < columnNames.Length; i++)
                {
                    Columns.Add(columnNames[i]);
                    sw.Write("\n" + columnNames[i]);

                }
                sw.Close();
            }


            Size = Columns.Count;

        }

        public Table(string name, string dir = "Tables")
        {

            Name = name;

            Path = $"Table/{dir}/{name}.txt";

            ColumnsPath = $"Table/ColumnsName/Columns{name}.txt";

            Columns = new List<string>();

            string[] columnNames = File.ReadAllLines(ColumnsPath);

            for (int i = 0; i < columnNames.Length; i++)
                Columns.Add(columnNames[i]);

            Size = Columns.Count;

        }

        public void AddNewRowToTable(string[] row)
        {
            string[] file = File.ReadAllLines(Path);
            StreamWriter sw = new StreamWriter(Path, true);

            if (file.Length == 0)
                sw.Write(row[0]);
            else
                sw.Write("\n" + row[0]);


            for (int i = 1; i < Size; i++)
                sw.Write("\n" + row[i]);

            sw.Close();
        }

        public void AddNewColumnToTable(string columnName, string defaultValue)
        {


            string[] file = File.ReadAllLines(ColumnsPath);
            bool is_here = false;
            for (int i = 0; i < file.Length; i++)
            {
                is_here = file[i] == columnName;
            }
            if (is_here == false)
            {
                Columns.Add(columnName);
                StreamWriter sw = new StreamWriter(ColumnsPath, true);
                sw.Write("\n" + columnName);
                sw.Close();
                Size++;
                file = File.ReadAllLines(Path);
                string[] row = new string[Size];
                sw = new StreamWriter(Path);
                sw.Close();

                for (int i = 0; i < file.Length;)
                {
                    for (int j = 0; j < Size - 1; j++)
                    {
                        row[j] = file[i++];
                    }
                    row[Size - 1] = defaultValue;

                    AddNewRowToTable(row);
                }
            }


        }

        public void DeleteRowToTable(int ID)
        {
            string[] file = File.ReadAllLines(Path);
            StreamWriter sw = new StreamWriter(Path, false);

            for (int i = 0; i < file.Length; i = i + Size)
            {
                if (i / Size == ID - 1)
                {
                    for (int j = 0; j < file.Length; j++)
                    {
                        if (j == i)
                        {
                            j = j + (Size - 1);
                        }
                        else
                        {
                            if (j == file.Length - 1)
                            {
                                sw.Write(file[j]);
                            }
                            else
                            {
                                sw.WriteLine(file[j]);
                            }

                        }
                    }
                    break;
                }
            }
            sw.Close();
        }

        public string[] ShowInfoAboutColumn(string Row, string parametr, string output)
        {
            int temp = -1;
            int temp1 = -1;
            for (int i = 0; i < Columns.Count; i++)
            {
                if (Columns[i] == Row)
                {
                    temp = i;
                    break;
                }
            }
            for (int i = 0; i < Columns.Count; i++)
            {
                if (Columns[i] == output)
                {
                    temp1 = i;
                    break;
                }
            }
            string[] exc = { "Ничего не найдено" };
            if (temp == -1 || temp1 == -1)
                return exc;

            string[] file = File.ReadAllLines(Path);
            int count = 0;
            for (int i = temp; i < file.Length; i = i + Size)
            {
                if (file[i] == parametr || parametr == "All")
                {
                    //Console.WriteLine(file[i - temp + temp1]);
                    //parameters[count] = file[i - temp + temp1];
                    count++;

                }
            }
            string[] parameters = new string[count];
            count = 0;
            for (int i = temp; i < file.Length; i = i + Size)
            {
                if (file[i] == parametr || parametr == "All")
                {
                    //Console.WriteLine(file[i - temp + temp1]);
                    parameters[count] = file[i - temp + temp1];
                    count++;

                }
            }
            return parameters;
        }

        public string[] ShowInfoAboutColumn(string Row1, string Row2, string parametr1, string parametr2, string output)
        {
            string[] result1 = ShowInfoAboutColumn(Row1, parametr1, Row2);
            string[] result2 = ShowInfoAboutColumn(Row1, parametr1, output);
            bool is_equal = false;
            int count = 0;
            for (int i = 0; i < result1.Length; i++)
            {
                for (int j = 0; j < result2.Length; j++)
                {
                    if (result1[i] == parametr2)
                    {
                        is_equal = true;
                    }
                }
                if (is_equal == true)
                {
                    count++;
                    is_equal = false;
                }
            }

            string[] parameters = new string[count];
            count = 0;
            for (int i = 0; i < result1.Length; i++)
            {
                for (int j = 0; j < result2.Length; j++)
                {
                    if (result1[i] == parametr2)
                    {
                        is_equal = true;
                        break;
                    }
                }
                if (is_equal == true)
                {
                    parameters[count] = result2[i];
                    count++;
                    is_equal = false;
                }
            }
            return parameters;
        }

        public void DeleteColumnToTable(int count)
        {
            string[] file = File.ReadAllLines(Path);
            StreamWriter sw = new StreamWriter(Path, false);
            int temp = count - 1;
            for (int i = 0; i < file.Length; i++)
            {
                if (i == temp)
                {
                    temp = temp + Size;
                }
                else
                {
                    if (i == file.Length - 1)
                    {
                        sw.Write(file[i]);
                    }
                    else
                    {
                        sw.WriteLine(file[i]);
                    }
                }
            }
            sw.Close();

            file = File.ReadAllLines(ColumnsPath);
            sw = new StreamWriter(ColumnsPath, false);
            for (int i = 0; i < file.Length; i++)
            {
                if (file[i] != Columns[Size - 1])
                {
                    if (i == 0)
                        sw.Write(file[i]);
                    else
                        sw.Write("\n" + file[i]);

                }

            }
            sw.Close();
        }

        public void DeleteColumnToTable(string columnName)
        {
            string[] file = File.ReadAllLines(Path);
            int length = file.Length / Size++ * Size;
            string[] row = new string[Size];
            StreamWriter sw = new StreamWriter(Path);
            sw.Close();

            for (int i = 0; i < file.Length;)
            {
                for (int j = 0; j < Size - 1; j++)
                {
                    row[j] = file[i++];
                }
                row[Size - 1] = "0";

                AddNewRowToTable(row);
            }
        }

        public string ReplaceValue(string ColumnsName, string[] Parameters, string input)
        {
            int temp = -1;
            for (int i = 0; i < Columns.Count; i++)
            {
                if (Columns[i] == ColumnsName)
                {
                    temp = i;
                    break;
                }
            }
            if (Parameters.Length != Size - 1 || temp == -1)
                return "Размер массива параметров меньше, чем необходимо!";

            bool is_here = false;

            string[] file = File.ReadAllLines(Path);
            for (int i = 0; i < file.Length; i += Size)
            {
                for (int j = 0; j < Parameters.Length; j++)
                {
                    if (file[i++] == Parameters[j] || j == temp)
                        is_here = true;
                    else
                    {
                        i -= j + 1;
                        is_here = false;
                        break;
                    }
                }
                if (is_here == true)
                {
                    file[i - (Size - (temp + 1))] = input;
                }

            }
            StreamWriter sw = new StreamWriter(Path, false);
            for (int i = 0; i < file.Length; i++)
            {
                if (i == 0)
                    sw.Write(file[i]);
                else
                    sw.Write("\n" + file[i]);
            }
            sw.Close();

            return " ";

        }

        public static void FillPattern(DateTime dateTime, string[] doctors)
        {
            string[] columnNames = { "Time", "DoctorName", "isRecorded" };
            Table table = new Table(dateTime.ToShortDateString(), columnNames, "Records");
            if (!File.Exists(table.Path))
            {
                StreamWriter sw = new StreamWriter("Table/Records/" + table.Name + ".txt");
                sw.Close();
                int time = 10;
                for (int i = 0; i < doctors.Length; i++)
                {
                    for (int j = 0; j < 8; j++)
                    {
                        string[] strings = { $"{time++}", doctors[i], $"{0}" };
                        table.AddNewRowToTable(strings);

                    }
                    time = 10;
                }
            }
        }

        public static void DeletePattern()
        {
            DateTime dateTime = DateTime.Now;
            DirectoryInfo dir = new DirectoryInfo(@"C:\Users\user\Desktop\FEFU\Прога\c#\Server\Server\bin\Debug\Table\Records");

            foreach (var item in dir.GetFiles())
            {
                string date = dateTime.ToShortDateString() + ".txt";

                if (date != item.Name)
                {
                    FileInfo fileInf = new FileInfo(@"C:\Users\user\Desktop\FEFU\Прога\c#\Server\Server\bin\Debug\Table\Records\" + item.Name);
                    fileInf.Delete();
                }
                dateTime = dateTime.AddDays(1);
            }
        }

    }
}
