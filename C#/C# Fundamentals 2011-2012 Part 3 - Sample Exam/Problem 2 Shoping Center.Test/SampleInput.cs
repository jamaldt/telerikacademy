using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;

namespace Problem2_Shoping_Center.Test
{
    [TestClass]
    public class SampleInput
    {
        [TestMethod(), Timeout(180000)]
        public void MainTest0000001()
        {
            String testInFile = @"Tests\test.000.001.in.txt";
            String testOutfile = @"Tests\test.000.001.out.txt";
            RunTest(testInFile, testOutfile);
        }

        private static void RunTest(string testInFile, string testOutfile)
        {
            String inputCommands = ReadFileToString(testInFile);
            string result = GetResult(inputCommands);

            String expectedOutput = ReadFileToString(testOutfile);

            Assert.AreEqual(expectedOutput, result);
        }

        private static string GetResult(String inputCommands)
        {
            string result = "";
            var input = new StringReader(inputCommands);
            using (input)
            {
                Console.SetIn(input);
                var output = new StringWriter();
                using (output)
                {
                    Console.SetOut(output);
                    Problem2_Shoping_Center.Program.Main();
                    result = output.ToString();
                }
            }

            return result;
        }

      

        [TestMethod(), Timeout(180000)]
        public void MainTest001()
        {
            String testInFile = @"Tests\test.001.in.txt";
            String testOutfile = @"Tests\test.001.out.txt";
            RunTest(testInFile, testOutfile);
        }

        [TestMethod(), Timeout(180000)]
        public void MainTest002()
        {
            String testInFile = @"Tests\test.002.in.txt";
            String testOutfile = @"Tests\test.002.out.txt";
            RunTest(testInFile, testOutfile);
        }

        [TestMethod(), Timeout(180000)]
        public void MainTest003()
        {
            String testInFile = @"Tests\test.003.in.txt";
            String testOutfile = @"Tests\test.003.out.txt";
            RunTest(testInFile, testOutfile);
        }

        [TestMethod(), Timeout(180000)]
        public void MainTest004()
        {
            String testInFile = @"Tests\test.004.in.txt";
            String testOutfile = @"Tests\test.004.out.txt";
            RunTest(testInFile, testOutfile);
        }


        [TestMethod(), Timeout(180000)]
        public void MainTest005()
        {
            String testInFile = @"Tests\test.005.in.txt";
            String testOutfile = @"Tests\test.005.out.txt";
            RunTest(testInFile, testOutfile);
        }

        private static string ReadFileToString(String testInFile)
        {

            StreamReader input = new StreamReader(testInFile);
            String output = "";
            try
            {
                using (input)
                {
                    output = input.ReadToEnd();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("The file could not be read:");
                Console.WriteLine(e.Message);
            }
            return output;
        }
    }
}
