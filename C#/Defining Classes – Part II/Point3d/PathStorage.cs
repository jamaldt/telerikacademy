using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Point3d
{
    static class PathStorage
    {
        public static Path LoadPath(string filePath)
        {
            if (String.IsNullOrWhiteSpace(filePath))
            {
                throw new ArgumentException("File name cannot be null or empty.");
            }

            if (!File.Exists(filePath))
            {
                throw new ArgumentException("The specified file doesn't exist in the local file system.");
            }

            Path path = new Path();

            using (StreamReader fileReader = new StreamReader(filePath))
            {
                string line;
                while ((line = fileReader.ReadLine()) != null)
                {
                    string[] coordinates = line.Split(new char[] { '.' }, StringSplitOptions.RemoveEmptyEntries);
                    int x;
                    int y;
                    int z;
                    if (coordinates.Length == 3 &&
                        Int32.TryParse(coordinates[0], out x) &&
                        Int32.TryParse(coordinates[1], out y) &&
                        Int32.TryParse(coordinates[2], out z))
                    {
                        Point3D point = new Point3D(x, y, z);
                        path.AddPoint(point);
                    }
                }
            }
            return path;
        }

        public static void SavePath(Path path, string filePath)
        {
            if (String.IsNullOrWhiteSpace(filePath))
            {
                throw new ArgumentException("File name cannot be null or empty.");
            }

            using (StreamWriter fileWriter = new StreamWriter(filePath, false))
            {
		for (int i = 0; i < path.Path.Count; i++)
                {
                    string line = String.Format("{0}.{1}.{2}", path.Path[i].X, path.Path[i].Y, path.Path[i].Z);
                    fileWriter.WriteLine(line);
                }
            }
        }

    }
}
