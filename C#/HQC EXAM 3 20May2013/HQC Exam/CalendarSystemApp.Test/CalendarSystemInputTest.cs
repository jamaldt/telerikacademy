using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;

namespace CalendarSystem.Test
{
    [TestClass]
    public class CalendarSystemInputTest
    {
        [TestMethod]
        public void MainTest000001()
        {
            var input = new StringReader(
                "AddEvent 2012-01-21T20:00:00 | party Viki | home" + Environment.NewLine +
                "AddEvent 2012-03-26T09:00:00 | C# exam" + Environment.NewLine +
                "AddEvent 2012-03-26T09:00:00 | C# exam" + Environment.NewLine +
                "AddEvent 2012-03-26T08:00:00 | C# exam" + Environment.NewLine +
                "AddEvent 2012-03-07T22:30:00 | party | Vitosha" + Environment.NewLine +
                "ListEvents 2012-03-07T08:00:00 | 3" + Environment.NewLine +
                "DeleteEvents c# exam" + Environment.NewLine +
                "DeleteEvents My granny's bushes" + Environment.NewLine +
                "ListEvents 2013-11-27T08:30:25 | 25" + Environment.NewLine +
                "AddEvent 2012-03-07T22:30:00 | party | Club XXX" + Environment.NewLine +
                "ListEvents 2012-01-07T20:00:00 | 10" + Environment.NewLine +
                "AddEvent 2012-03-07T22:30:00 | Party | Club XXX" + Environment.NewLine +
                "ListEvents 2012-03-07T22:30:00 | 3" + Environment.NewLine +
                "End" + Environment.NewLine);

            string expected = 
                "Event added" + Environment.NewLine +
                "Event added" + Environment.NewLine +
                "Event added" + Environment.NewLine +
                "Event added" + Environment.NewLine +
                "Event added" + Environment.NewLine +
                "2012-03-07T22:30:00 | party | Vitosha" + Environment.NewLine +
                "2012-03-26T08:00:00 | C# exam" + Environment.NewLine +
                "2012-03-26T09:00:00 | C# exam" + Environment.NewLine +
                "3 events deleted" + Environment.NewLine +
                "No events found" + Environment.NewLine +
                "No events found" + Environment.NewLine +
                "Event added" + Environment.NewLine +
                "2012-01-21T20:00:00 | party Viki | home" + Environment.NewLine +
                "2012-03-07T22:30:00 | party | Club XXX" + Environment.NewLine +
                "2012-03-07T22:30:00 | party | Vitosha" + Environment.NewLine +
                "Event added" + Environment.NewLine +
                "2012-03-07T22:30:00 | party | Club XXX" + Environment.NewLine +
                "2012-03-07T22:30:00 | party | Vitosha" + Environment.NewLine +
                "2012-03-07T22:30:00 | Party | Club XXX" + Environment.NewLine;

            using (input)
            {
                Console.SetIn(input);

                var output = new StringWriter();
                using (output)
                {
                    Console.SetOut(output);

                    CalendarSystemNS.CalendarSystem.Main();

                    string actual = output.ToString();
                    Assert.AreEqual(expected, actual);
                }
            }
        }

        [TestMethod]
        public void MainTest001()
        {
            var input = new StringReader(
                "AddEvent 2000-01-01T01:00:00 | party Viki | home" + Environment.NewLine +
                "End" + Environment.NewLine
                );

            string expected = "Event added" + Environment.NewLine;

            using (input)
            {
                Console.SetIn(input);

                var output = new StringWriter();
                using (output)
                {
                    Console.SetOut(output);

                    CalendarSystemNS.CalendarSystem.Main();

                    string actual = output.ToString();
                    Assert.AreEqual(expected, actual);
                }
            }
        }

        [TestMethod]
        public void MainTest002()
        {
            var input = new StringReader(
                "AddEvent 2000-01-01T01:00:00 | party Viki | home" + Environment.NewLine +
                "ListEvents 2000-01-01T01:00:00 | 1" + Environment.NewLine +
                "End" + Environment.NewLine
                );

            string expected = "Event added" + Environment.NewLine +
                "2000-01-01T01:00:00 | party Viki | home" + Environment.NewLine;

            using (input)
            {
                Console.SetIn(input);

                var output = new StringWriter();
                using (output)
                {
                    Console.SetOut(output);

                    CalendarSystemNS.CalendarSystem.Main();

                    string actual = output.ToString();
                    Assert.AreEqual(expected, actual);
                }
            }
        }

        [TestMethod]
        public void MainTest003()
        {
            var input = new StringReader(
                "AddEvent 2000-01-01T01:00:00 | party Viki | home" + Environment.NewLine +
                "AddEvent 2000-01-01T02:00:00 | party Viki (again) | home" + Environment.NewLine +
                "ListEvents 2000-01-01T01:00:01 | 2" + Environment.NewLine +
                "End" + Environment.NewLine
                );

            string expected = 
                "Event added" + Environment.NewLine +
                "Event added" + Environment.NewLine +
                "2000-01-01T02:00:00 | party Viki (again) | home" + Environment.NewLine;

            using (input)
            {
                Console.SetIn(input);

                var output = new StringWriter();
                using (output)
                {
                    Console.SetOut(output);

                    CalendarSystemNS.CalendarSystem.Main();

                    string actual = output.ToString();
                    Assert.AreEqual(expected, actual);
                }
            }
        }

        [TestMethod]
        public void MainTest004()
        {
            var input = new StringReader(
                "AddEvent 2011-11-11T11:11:22 | party Viki | home" + Environment.NewLine +
                "AddEvent 2011-11-11T11:11:22 | party Viki" + Environment.NewLine +
                "AddEvent 2011-11-11T11:11:55 | party Viki | home" + Environment.NewLine +
                "AddEvent 2011-11-11T11:11:33 | party Viki" + Environment.NewLine +
                "AddEvent 2011-11-11T11:11:11 | party Viki | home" + Environment.NewLine +
                "AddEvent 2011-11-11T11:11:44 | party Viki" + Environment.NewLine +
                "AddEvent 2011-11-11T11:11:55 | party Viki" + Environment.NewLine +
                "AddEvent 2011-11-11T11:11:33 | party Viki | home" + Environment.NewLine +
                "AddEvent 2011-11-11T11:11:11 | party Viki" + Environment.NewLine +
                "AddEvent 2011-11-11T11:11:44 | party Viki | home" + Environment.NewLine +
                "ListEvents 2011-11-11T11:11:22 | 5" + Environment.NewLine +
                "End" + Environment.NewLine
                );

            string expected =
                "Event added" + Environment.NewLine +
                "Event added" + Environment.NewLine +
                "Event added" + Environment.NewLine +
                "Event added" + Environment.NewLine +
                "Event added" + Environment.NewLine +
                "Event added" + Environment.NewLine +
                "Event added" + Environment.NewLine +
                "Event added" + Environment.NewLine +
                "Event added" + Environment.NewLine +
                "Event added" + Environment.NewLine +
                "2011-11-11T11:11:22 | party Viki" + Environment.NewLine +
                "2011-11-11T11:11:22 | party Viki | home" + Environment.NewLine +
                "2011-11-11T11:11:33 | party Viki" + Environment.NewLine +
                "2011-11-11T11:11:33 | party Viki | home" + Environment.NewLine +
                "2011-11-11T11:11:44 | party Viki" + Environment.NewLine
                ;
            using (input)
            {
                Console.SetIn(input);

                var output = new StringWriter();
                using (output)
                {
                    Console.SetOut(output);

                    CalendarSystemNS.CalendarSystem.Main();

                    string actual = output.ToString();
                    Assert.AreEqual(expected, actual);
                }
            }
        }

        [TestMethod]
        public void MainTest005()
        {
            var input = new StringReader(
                "DeleteEvents party @ Mimi" + Environment.NewLine +
                "DeleteEvents party Viki 22" + Environment.NewLine +
                "AddEvent 2011-11-11T11:11:22 | party Viki 22 | home" + Environment.NewLine +
                "AddEvent 2011-11-11T11:11:22 | party Viki (11:22)" + Environment.NewLine +
                "AddEvent 2011-11-11T11:11:55 | party Viki 55 | home" + Environment.NewLine +
                "AddEvent 2011-11-11T11:11:33 | party Viki (11:33)" + Environment.NewLine +
                "AddEvent 2011-11-11T11:11:11 | party Viki 11 | home" + Environment.NewLine +
                "AddEvent 2011-11-11T11:11:44 | party Viki (11:44)" + Environment.NewLine +
                "AddEvent 2011-11-11T11:11:55 | party Viki (11:55)" + Environment.NewLine +
                "AddEvent 2011-11-11T11:11:33 | party Viki 33 | home" + Environment.NewLine +
                "AddEvent 2011-11-11T11:11:11 | party Viki (11:11)" + Environment.NewLine +
                "AddEvent 2011-11-11T11:11:44 | party Viki | home" + Environment.NewLine +
                "ListEvents 2011-11-11T11:11:22 | 3" + Environment.NewLine +
                "DeleteEvents party @ Kiro" + Environment.NewLine +
                "ListEvents 2011-11-11T11:11:11 | 2" + Environment.NewLine +
                "End" + Environment.NewLine
                );

            string expected =
                "No events found" + Environment.NewLine +
                "No events found" + Environment.NewLine +
                "Event added" + Environment.NewLine +
                "Event added" + Environment.NewLine +
                "Event added" + Environment.NewLine +
                "Event added" + Environment.NewLine +
                "Event added" + Environment.NewLine +
                "Event added" + Environment.NewLine +
                "Event added" + Environment.NewLine +
                "Event added" + Environment.NewLine +
                "Event added" + Environment.NewLine +
                "Event added" + Environment.NewLine +
                "2011-11-11T11:11:22 | party Viki (11:22)" + Environment.NewLine +
                "2011-11-11T11:11:22 | party Viki 22 | home" + Environment.NewLine +
                "2011-11-11T11:11:33 | party Viki (11:33)" + Environment.NewLine +
                "No events found" + Environment.NewLine +
                "2011-11-11T11:11:11 | party Viki (11:11)" + Environment.NewLine +
                "2011-11-11T11:11:11 | party Viki 11 | home" + Environment.NewLine
                ;
            using (input)
            {
                Console.SetIn(input);

                var output = new StringWriter();
                using (output)
                {
                    Console.SetOut(output);

                    CalendarSystemNS.CalendarSystem.Main();

                    string actual = output.ToString();
                    Assert.AreEqual(expected, actual);
                }
            }
        }

        [TestMethod]
        public void MainTest006()
        {
            var input = new StringReader(
                "AddEvent 2010-01-01T00:00:00 | party Viki 2010" + Environment.NewLine +
                "AddEvent 2010-01-01T00:00:00 | Party VIKI" + Environment.NewLine +
                "AddEvent 2011-11-11T11:11:22 | party Viki | home" + Environment.NewLine +
                "AddEvent 2011-11-11T11:11:22 | Party Viki" + Environment.NewLine +
                "AddEvent 2011-11-11T11:11:22 | party Viki" + Environment.NewLine +
                "AddEvent 2011-11-11T11:11:22 | party Viki" + Environment.NewLine +
                "AddEvent 2011-11-11T11:11:55 | party Viki | home" + Environment.NewLine +
                "AddEvent 2011-11-11T11:11:33 | party Viki" + Environment.NewLine +
                "AddEvent 2012-03-27T07:07:07 | party Kiro - 7 km" + Environment.NewLine +
                "DeleteEvents party Viki" + Environment.NewLine +
                "DeleteEvents party Viki" + Environment.NewLine +
                "AddEvent 2011-11-11T11:11:11 | party Viki | home" + Environment.NewLine +
                "AddEvent 2011-11-11T11:11:44 | party viki" + Environment.NewLine +
                "AddEvent 2011-11-11T11:11:55 | Party Viki" + Environment.NewLine +
                "AddEvent 2010-01-01T00:00:00 | party Viki 2010" + Environment.NewLine +
                "AddEvent 2011-11-11T11:11:44 | PaRtY ViKi" + Environment.NewLine +
                "AddEvent 2010-01-01T00:00:00 | Party VIKI" + Environment.NewLine +
                "AddEvent 2011-11-11T11:11:55 | party VIKI" + Environment.NewLine +
                "AddEvent 2011-11-11T11:11:55 | party Viki" + Environment.NewLine +
                "AddEvent 2011-11-11T11:11:33 | party Viki | home" + Environment.NewLine +
                "AddEvent 2011-11-11T11:11:11 | pArtY VikI" + Environment.NewLine +
                "AddEvent 2011-11-11T11:11:44 | party Viki | home" + Environment.NewLine +
                "AddEvent 2011-11-11T11:11:44 | party Viki | alpha" + Environment.NewLine +
                "AddEvent 2011-11-11T11:11:22 | PARTY VIKI" + Environment.NewLine +
                "AddEvent 2011-11-11T11:11:22 | Party Viki" + Environment.NewLine +
                "AddEvent 2011-11-11T11:11:22 | party 11:22 @ Mimi" + Environment.NewLine +
                "ListEvents 2011-11-11T11:11:22 | 10" + Environment.NewLine +
                "ListEvents 2011-11-11T11:11:22 | 5" + Environment.NewLine +
                "AddEvent 2010-01-01T00:00:00 | party Viki 2010" + Environment.NewLine +
                "AddEvent 2010-01-01T00:00:00 | Party VIKI" + Environment.NewLine +
                "AddEvent 2011-11-11T11:11:22 | party Viki | home" + Environment.NewLine +
                "AddEvent 2011-11-11T11:11:22 | Party Viki" + Environment.NewLine +
                "AddEvent 2011-11-11T11:11:22 | party Viki" + Environment.NewLine +
                "AddEvent 2011-11-11T11:11:22 | party Viki" + Environment.NewLine +
                "AddEvent 2011-11-11T11:11:55 | party Viki | home" + Environment.NewLine +
                "AddEvent 2011-11-11T11:11:33 | party Viki" + Environment.NewLine +
                "AddEvent 2012-03-27T07:07:07 | party Kiro - 7 km" + Environment.NewLine +
                "AddEvent 2010-01-01T00:00:00 | party Viki 2010" + Environment.NewLine +
                "AddEvent 2010-01-01T00:00:00 | Party VIKI" + Environment.NewLine +
                "AddEvent 2011-11-11T11:11:22 | party Viki | home" + Environment.NewLine +
                "AddEvent 2011-11-11T11:11:22 | Party Viki" + Environment.NewLine +
                "AddEvent 2011-11-11T11:11:22 | party Viki" + Environment.NewLine +
                "AddEvent 2011-11-11T11:11:22 | party Viki" + Environment.NewLine +
                "AddEvent 2011-11-11T11:11:55 | party Viki | home" + Environment.NewLine +
                "AddEvent 2011-11-11T11:11:33 | party Viki" + Environment.NewLine +
                "AddEvent 2012-03-27T07:07:07 | party Kiro - 7 km" + Environment.NewLine +
                "AddEvent 2010-01-01T00:00:00 | party Viki 2010" + Environment.NewLine +
                "AddEvent 2010-01-01T00:00:00 | Party VIKI" + Environment.NewLine +
                "AddEvent 2011-11-11T11:11:22 | party Viki | home" + Environment.NewLine +
                "AddEvent 2011-11-11T11:11:22 | Party Viki" + Environment.NewLine +
                "AddEvent 2011-11-11T11:11:22 | party Viki" + Environment.NewLine +
                "AddEvent 2011-11-11T11:11:22 | party Viki" + Environment.NewLine +
                "AddEvent 2011-11-11T11:11:55 | party Viki | home" + Environment.NewLine +
                "AddEvent 2011-11-11T11:11:33 | party Viki" + Environment.NewLine +
                "AddEvent 2012-03-27T07:07:07 | party Kiro - 7 km" + Environment.NewLine +
                "AddEvent 2010-01-01T00:00:00 | party Viki 2010" + Environment.NewLine +
                "AddEvent 2010-01-01T00:00:00 | Party VIKI" + Environment.NewLine +
                "AddEvent 2011-11-11T11:11:22 | party Viki | home" + Environment.NewLine +
                "AddEvent 2011-11-11T11:11:22 | Party Viki" + Environment.NewLine +
                "AddEvent 2011-11-11T11:11:22 | party Viki" + Environment.NewLine +
                "AddEvent 2011-11-11T11:11:22 | party Viki" + Environment.NewLine +
                "AddEvent 2011-11-11T11:11:55 | party Viki | home" + Environment.NewLine +
                "AddEvent 2011-11-11T11:11:33 | party Viki" + Environment.NewLine +
                "AddEvent 2012-03-27T07:07:07 | party Kiro - 7 km" + Environment.NewLine +
                "AddEvent 2011-11-11T11:11:11 | party Viki | home" + Environment.NewLine +
                "AddEvent 2011-11-11T11:11:44 | party viki" + Environment.NewLine +
                "AddEvent 2011-11-11T11:11:55 | Party Viki" + Environment.NewLine +
                "AddEvent 2010-01-01T00:00:00 | party Viki 2010" + Environment.NewLine +
                "AddEvent 2011-11-11T11:11:44 | PaRtY ViKi" + Environment.NewLine +
                "AddEvent 2010-01-01T00:00:00 | Party VIKI" + Environment.NewLine +
                "AddEvent 2011-11-11T11:11:55 | party VIKI" + Environment.NewLine +
                "AddEvent 2011-11-11T11:11:55 | party Viki" + Environment.NewLine +
                "AddEvent 2011-11-11T11:11:33 | party Viki | home" + Environment.NewLine +
                "AddEvent 2011-11-11T11:11:11 | pArtY VikI" + Environment.NewLine +
                "AddEvent 2011-11-11T11:11:44 | party Viki | home" + Environment.NewLine +
                "AddEvent 2011-11-11T11:11:44 | party Viki | alpha" + Environment.NewLine +
                "AddEvent 2011-11-11T11:11:22 | PARTY VIKI" + Environment.NewLine +
                "AddEvent 2011-11-11T11:11:22 | Party Viki" + Environment.NewLine +
                "AddEvent 2011-11-11T11:11:22 | party 11:22 @ Mimi" + Environment.NewLine +
                "AddEvent 2011-11-11T11:11:11 | party Viki | home" + Environment.NewLine +
                "AddEvent 2011-11-11T11:11:44 | party viki" + Environment.NewLine +
                "AddEvent 2011-11-11T11:11:55 | Party Viki" + Environment.NewLine +
                "AddEvent 2010-01-01T00:00:00 | party Viki 2010" + Environment.NewLine +
                "AddEvent 2011-11-11T11:11:44 | PaRtY ViKi" + Environment.NewLine +
                "AddEvent 2010-01-01T00:00:00 | Party VIKI" + Environment.NewLine +
                "AddEvent 2011-11-11T11:11:55 | party VIKI" + Environment.NewLine +
                "AddEvent 2011-11-11T11:11:55 | party Viki" + Environment.NewLine +
                "AddEvent 2011-11-11T11:11:33 | party Viki | home" + Environment.NewLine +
                "AddEvent 2011-11-11T11:11:11 | pArtY VikI" + Environment.NewLine +
                "AddEvent 2011-11-11T11:11:44 | party Viki | home" + Environment.NewLine +
                "AddEvent 2011-11-11T11:11:44 | party Viki | alpha" + Environment.NewLine +
                "AddEvent 2011-11-11T11:11:22 | PARTY VIKI" + Environment.NewLine +
                "AddEvent 2011-11-11T11:11:22 | Party Viki" + Environment.NewLine +
                "AddEvent 2011-11-11T11:11:22 | party 11:22 @ Mimi" + Environment.NewLine +
                "ListEvents 2011-11-11T11:11:22 | 100" + Environment.NewLine +
                "ListEvents 2000-01-01T00:00:00 | 5" + Environment.NewLine +
                "ListEvents 2020-01-01T00:00:00 | 5" + Environment.NewLine +
                "DeleteEvents party Viki" + Environment.NewLine +
                "DeleteEvents party Viki" + Environment.NewLine +
                "DeleteEvents party Viki" + Environment.NewLine +
                "DeleteEvents party Viki" + Environment.NewLine +
                "DeleteEvents party Viki" + Environment.NewLine +
                "DeleteEvents party Viki" + Environment.NewLine +
                "DeleteEvents party Viki" + Environment.NewLine +
                "DeleteEvents party Viki" + Environment.NewLine +
                "DeleteEvents party Viki" + Environment.NewLine +
                "DeleteEvents party Viki" + Environment.NewLine +
                "DeleteEvents party Viki" + Environment.NewLine +
                "DeleteEvents party Viki" + Environment.NewLine +
                "DeleteEvents party Viki" + Environment.NewLine +
                "DeleteEvents party Viki" + Environment.NewLine +
                "DeleteEvents party Viki" + Environment.NewLine +
                "DeleteEvents party Viki" + Environment.NewLine +
                "DeleteEvents party Viki" + Environment.NewLine +
                "DeleteEvents party Viki" + Environment.NewLine +
                "DeleteEvents party Viki" + Environment.NewLine +
                "DeleteEvents party Viki" + Environment.NewLine +
                "DeleteEvents party Viki" + Environment.NewLine +
                "DeleteEvents party Viki" + Environment.NewLine +
                "DeleteEvents party Viki" + Environment.NewLine +
                "DeleteEvents party Viki" + Environment.NewLine +
                "ListEvents 2011-11-11T11:11:22 | 5" + Environment.NewLine +
                "End" + Environment.NewLine
                );

            string expected =
                "Event added" + Environment.NewLine +
                "Event added" + Environment.NewLine +
                "Event added" + Environment.NewLine +
                "Event added" + Environment.NewLine +
                "Event added" + Environment.NewLine +
                "Event added" + Environment.NewLine +
                "Event added" + Environment.NewLine +
                "Event added" + Environment.NewLine +
                "Event added" + Environment.NewLine +
                "7 events deleted" + Environment.NewLine +
                "No events found" + Environment.NewLine +
                "Event added" + Environment.NewLine +
                "Event added" + Environment.NewLine +
                "Event added" + Environment.NewLine +
                "Event added" + Environment.NewLine +
                "Event added" + Environment.NewLine +
                "Event added" + Environment.NewLine +
                "Event added" + Environment.NewLine +
                "Event added" + Environment.NewLine +
                "Event added" + Environment.NewLine +
                "Event added" + Environment.NewLine +
                "Event added" + Environment.NewLine +
                "Event added" + Environment.NewLine +
                "Event added" + Environment.NewLine +
                "Event added" + Environment.NewLine +
                "Event added" + Environment.NewLine +
                "2011-11-11T11:11:22 | party 11:22 @ Mimi" + Environment.NewLine +
                "2011-11-11T11:11:22 | Party Viki" + Environment.NewLine +
                "2011-11-11T11:11:22 | PARTY VIKI" + Environment.NewLine +
                "2011-11-11T11:11:33 | party Viki | home" + Environment.NewLine +
                "2011-11-11T11:11:44 | party viki" + Environment.NewLine +
                "2011-11-11T11:11:44 | party Viki | alpha" + Environment.NewLine +
                "2011-11-11T11:11:44 | party Viki | home" + Environment.NewLine +
                "2011-11-11T11:11:44 | PaRtY ViKi" + Environment.NewLine +
                "2011-11-11T11:11:55 | party Viki" + Environment.NewLine +
                "2011-11-11T11:11:55 | party VIKI" + Environment.NewLine +
                "2011-11-11T11:11:22 | party 11:22 @ Mimi" + Environment.NewLine +
                "2011-11-11T11:11:22 | Party Viki" + Environment.NewLine +
                "2011-11-11T11:11:22 | PARTY VIKI" + Environment.NewLine +
                "2011-11-11T11:11:33 | party Viki | home" + Environment.NewLine +
                "2011-11-11T11:11:44 | party viki" + Environment.NewLine +
                "Event added" + Environment.NewLine +
                "Event added" + Environment.NewLine +
                "Event added" + Environment.NewLine +
                "Event added" + Environment.NewLine +
                "Event added" + Environment.NewLine +
                "Event added" + Environment.NewLine +
                "Event added" + Environment.NewLine +
                "Event added" + Environment.NewLine +
                "Event added" + Environment.NewLine +
                "Event added" + Environment.NewLine +
                "Event added" + Environment.NewLine +
                "Event added" + Environment.NewLine +
                "Event added" + Environment.NewLine +
                "Event added" + Environment.NewLine +
                "Event added" + Environment.NewLine +
                "Event added" + Environment.NewLine +
                "Event added" + Environment.NewLine +
                "Event added" + Environment.NewLine +
                "Event added" + Environment.NewLine +
                "Event added" + Environment.NewLine +
                "Event added" + Environment.NewLine +
                "Event added" + Environment.NewLine +
                "Event added" + Environment.NewLine +
                "Event added" + Environment.NewLine +
                "Event added" + Environment.NewLine +
                "Event added" + Environment.NewLine +
                "Event added" + Environment.NewLine +
                "Event added" + Environment.NewLine +
                "Event added" + Environment.NewLine +
                "Event added" + Environment.NewLine +
                "Event added" + Environment.NewLine +
                "Event added" + Environment.NewLine +
                "Event added" + Environment.NewLine +
                "Event added" + Environment.NewLine +
                "Event added" + Environment.NewLine +
                "Event added" + Environment.NewLine +
                "Event added" + Environment.NewLine +
                "Event added" + Environment.NewLine +
                "Event added" + Environment.NewLine +
                "Event added" + Environment.NewLine +
                "Event added" + Environment.NewLine +
                "Event added" + Environment.NewLine +
                "Event added" + Environment.NewLine +
                "Event added" + Environment.NewLine +
                "Event added" + Environment.NewLine +
                "Event added" + Environment.NewLine +
                "Event added" + Environment.NewLine +
                "Event added" + Environment.NewLine +
                "Event added" + Environment.NewLine +
                "Event added" + Environment.NewLine +
                "Event added" + Environment.NewLine +
                "Event added" + Environment.NewLine +
                "Event added" + Environment.NewLine +
                "Event added" + Environment.NewLine +
                "Event added" + Environment.NewLine +
                "Event added" + Environment.NewLine +
                "Event added" + Environment.NewLine +
                "Event added" + Environment.NewLine +
                "Event added" + Environment.NewLine +
                "Event added" + Environment.NewLine +
                "Event added" + Environment.NewLine +
                "Event added" + Environment.NewLine +
                "Event added" + Environment.NewLine +
                "Event added" + Environment.NewLine +
                "Event added" + Environment.NewLine +
                "Event added" + Environment.NewLine +
                "2011-11-11T11:11:22 | party 11:22 @ Mimi" + Environment.NewLine +
                "2011-11-11T11:11:22 | party 11:22 @ Mimi" + Environment.NewLine +
                "2011-11-11T11:11:22 | party 11:22 @ Mimi" + Environment.NewLine +
                "2011-11-11T11:11:22 | party Viki" + Environment.NewLine +
                "2011-11-11T11:11:22 | party Viki" + Environment.NewLine +
                "2011-11-11T11:11:22 | party Viki" + Environment.NewLine +
                "2011-11-11T11:11:22 | party Viki" + Environment.NewLine +
                "2011-11-11T11:11:22 | party Viki" + Environment.NewLine +
                "2011-11-11T11:11:22 | party Viki" + Environment.NewLine +
                "2011-11-11T11:11:22 | party Viki" + Environment.NewLine +
                "2011-11-11T11:11:22 | party Viki" + Environment.NewLine +
                "2011-11-11T11:11:22 | party Viki | home" + Environment.NewLine +
                "2011-11-11T11:11:22 | party Viki | home" + Environment.NewLine +
                "2011-11-11T11:11:22 | party Viki | home" + Environment.NewLine +
                "2011-11-11T11:11:22 | party Viki | home" + Environment.NewLine +
                "2011-11-11T11:11:22 | Party Viki" + Environment.NewLine +
                "2011-11-11T11:11:22 | Party Viki" + Environment.NewLine +
                "2011-11-11T11:11:22 | Party Viki" + Environment.NewLine +
                "2011-11-11T11:11:22 | Party Viki" + Environment.NewLine +
                "2011-11-11T11:11:22 | Party Viki" + Environment.NewLine +
                "2011-11-11T11:11:22 | Party Viki" + Environment.NewLine +
                "2011-11-11T11:11:22 | Party Viki" + Environment.NewLine +
                "2011-11-11T11:11:22 | PARTY VIKI" + Environment.NewLine +
                "2011-11-11T11:11:22 | PARTY VIKI" + Environment.NewLine +
                "2011-11-11T11:11:22 | PARTY VIKI" + Environment.NewLine +
                "2011-11-11T11:11:33 | party Viki" + Environment.NewLine +
                "2011-11-11T11:11:33 | party Viki" + Environment.NewLine +
                "2011-11-11T11:11:33 | party Viki" + Environment.NewLine +
                "2011-11-11T11:11:33 | party Viki" + Environment.NewLine +
                "2011-11-11T11:11:33 | party Viki | home" + Environment.NewLine +
                "2011-11-11T11:11:33 | party Viki | home" + Environment.NewLine +
                "2011-11-11T11:11:33 | party Viki | home" + Environment.NewLine +
                "2011-11-11T11:11:44 | party viki" + Environment.NewLine +
                "2011-11-11T11:11:44 | party viki" + Environment.NewLine +
                "2011-11-11T11:11:44 | party viki" + Environment.NewLine +
                "2011-11-11T11:11:44 | party Viki | alpha" + Environment.NewLine +
                "2011-11-11T11:11:44 | party Viki | alpha" + Environment.NewLine +
                "2011-11-11T11:11:44 | party Viki | alpha" + Environment.NewLine +
                "2011-11-11T11:11:44 | party Viki | home" + Environment.NewLine +
                "2011-11-11T11:11:44 | party Viki | home" + Environment.NewLine +
                "2011-11-11T11:11:44 | party Viki | home" + Environment.NewLine +
                "2011-11-11T11:11:44 | PaRtY ViKi" + Environment.NewLine +
                "2011-11-11T11:11:44 | PaRtY ViKi" + Environment.NewLine +
                "2011-11-11T11:11:44 | PaRtY ViKi" + Environment.NewLine +
                "2011-11-11T11:11:55 | party Viki" + Environment.NewLine +
                "2011-11-11T11:11:55 | party Viki" + Environment.NewLine +
                "2011-11-11T11:11:55 | party Viki" + Environment.NewLine +
                "2011-11-11T11:11:55 | party Viki | home" + Environment.NewLine +
                "2011-11-11T11:11:55 | party Viki | home" + Environment.NewLine +
                "2011-11-11T11:11:55 | party Viki | home" + Environment.NewLine +
                "2011-11-11T11:11:55 | party Viki | home" + Environment.NewLine +
                "2011-11-11T11:11:55 | party VIKI" + Environment.NewLine +
                "2011-11-11T11:11:55 | party VIKI" + Environment.NewLine +
                "2011-11-11T11:11:55 | party VIKI" + Environment.NewLine +
                "2011-11-11T11:11:55 | Party Viki" + Environment.NewLine +
                "2011-11-11T11:11:55 | Party Viki" + Environment.NewLine +
                "2011-11-11T11:11:55 | Party Viki" + Environment.NewLine +
                "2012-03-27T07:07:07 | party Kiro - 7 km" + Environment.NewLine +
                "2012-03-27T07:07:07 | party Kiro - 7 km" + Environment.NewLine +
                "2012-03-27T07:07:07 | party Kiro - 7 km" + Environment.NewLine +
                "2012-03-27T07:07:07 | party Kiro - 7 km" + Environment.NewLine +
                "2012-03-27T07:07:07 | party Kiro - 7 km" + Environment.NewLine +
                "2010-01-01T00:00:00 | Party VIKI" + Environment.NewLine +
                "2010-01-01T00:00:00 | Party VIKI" + Environment.NewLine +
                "2010-01-01T00:00:00 | Party VIKI" + Environment.NewLine +
                "2010-01-01T00:00:00 | Party VIKI" + Environment.NewLine +
                "2010-01-01T00:00:00 | Party VIKI" + Environment.NewLine +
                "No events found" + Environment.NewLine +
                "67 events deleted" + Environment.NewLine +
                "No events found" + Environment.NewLine +
                "No events found" + Environment.NewLine +
                "No events found" + Environment.NewLine +
                "No events found" + Environment.NewLine +
                "No events found" + Environment.NewLine +
                "No events found" + Environment.NewLine +
                "No events found" + Environment.NewLine +
                "No events found" + Environment.NewLine +
                "No events found" + Environment.NewLine +
                "No events found" + Environment.NewLine +
                "No events found" + Environment.NewLine +
                "No events found" + Environment.NewLine +
                "No events found" + Environment.NewLine +
                "No events found" + Environment.NewLine +
                "No events found" + Environment.NewLine +
                "No events found" + Environment.NewLine +
                "No events found" + Environment.NewLine +
                "No events found" + Environment.NewLine +
                "No events found" + Environment.NewLine +
                "No events found" + Environment.NewLine +
                "No events found" + Environment.NewLine +
                "No events found" + Environment.NewLine +
                "No events found" + Environment.NewLine +
                "2011-11-11T11:11:22 | party 11:22 @ Mimi" + Environment.NewLine +
                "2011-11-11T11:11:22 | party 11:22 @ Mimi" + Environment.NewLine +
                "2011-11-11T11:11:22 | party 11:22 @ Mimi" + Environment.NewLine +
                "2012-03-27T07:07:07 | party Kiro - 7 km" + Environment.NewLine +
                "2012-03-27T07:07:07 | party Kiro - 7 km" + Environment.NewLine
                ;
            using (input)
            {
                Console.SetIn(input);

                var output = new StringWriter();
                using (output)
                {
                    Console.SetOut(output);

                    CalendarSystemNS.CalendarSystem.Main();

                    string actual = output.ToString();
                    Assert.AreEqual(expected, actual);
                }
            }
        }

        [TestMethod]
        public void MainTest007()
        {
            var input = new StringReader(
                "AddEvent 2001-01-01T10:30:03 | party Kiro" + Environment.NewLine +
                "AddEvent 2019-01-01T00:00:00 | C# exam (again) | at home" + Environment.NewLine +
                "AddEvent 2001-01-01T10:00:00 | party Kiro - 645831 |  - 599812" + Environment.NewLine +
                "AddEvent 2001-02-01T00:00:00 | Exam | Plovdiv" + Environment.NewLine +
                "AddEvent 2001-02-01T00:00:00 | party Lora" + Environment.NewLine +
                "AddEvent 2001-01-01T00:00:00 | Exam | Home" + Environment.NewLine +
                "AddEvent 2012-03-31T23:59:58 | party Kiro - 744173 | Varna - 771418" + Environment.NewLine +
                "AddEvent 2001-01-01T10:30:01 | EXAM - 197258" + Environment.NewLine +
                "AddEvent 2001-01-01T10:30:00 | C# exam (again) | sofia" + Environment.NewLine +
                "AddEvent 2012-03-31T23:59:59 | exam" + Environment.NewLine +
                "AddEvent 2001-01-01T16:00:00 | party Lora" + Environment.NewLine +
                "AddEvent 2019-01-01T00:00:00 | C# course |  - 531989" + Environment.NewLine +
                "AddEvent 2001-01-01T10:00:00 | party | Home" + Environment.NewLine +
                "AddEvent 2000-01-01T00:00:00 | Party LORA | Telerik academy - 14832" + Environment.NewLine +
                "AddEvent 2001-01-01T22:00:00 | PARTY | home" + Environment.NewLine +
                "AddEvent 2001-01-01T22:30:00 | Party LORA - 986290 | home" + Environment.NewLine +
                "AddEvent 2001-01-01T22:00:00 | Party LORA - 791305" + Environment.NewLine +
                "AddEvent 2001-02-01T00:00:00 | Party LORA - 85232" + Environment.NewLine +
                "AddEvent 2001-01-01T22:00:00 | party | sofia" + Environment.NewLine +
                "AddEvent 2001-01-01T11:00:00 | party Kiro - 384003 | telerik academy" + Environment.NewLine +
                "AddEvent 2019-01-01T00:00:00 | exam - 59365" + Environment.NewLine +
                "AddEvent 2001-01-01T10:30:02 | PARTY" + Environment.NewLine +
                "AddEvent 2001-01-01T12:00:00 | party Lora - 243949" + Environment.NewLine +
                "AddEvent 2001-01-01T10:30:02 | Rock party | at home" + Environment.NewLine +
                "AddEvent 2001-01-01T10:30:02 | C# course" + Environment.NewLine +
                "AddEvent 2001-01-01T00:00:00 | PARTY - 352449 |  - 408337" + Environment.NewLine +
                "AddEvent 2001-01-01T11:00:00 | Rock party | Home - 397026" + Environment.NewLine +
                "AddEvent 2001-01-01T10:30:02 | Rock party" + Environment.NewLine +
                "AddEvent 2001-01-01T10:30:01 | party Lora | Kaspichan" + Environment.NewLine +
                "AddEvent 2001-01-01T10:30:00 | Party LORA | Sofia" + Environment.NewLine +
                "AddEvent 2001-01-01T10:30:00 | Chalga party | at home - 222820" + Environment.NewLine +
                "AddEvent 2001-01-01T12:00:00 | exam" + Environment.NewLine +
                "AddEvent 2019-01-01T00:00:00 | Chalga party | Varna" + Environment.NewLine +
                "AddEvent 2019-01-01T00:00:00 | party - 416966" + Environment.NewLine +
                "AddEvent 2012-03-31T23:59:57 | EXAM - 194681 | at school" + Environment.NewLine +
                "AddEvent 2001-01-01T11:30:00 | Party LORA | home" + Environment.NewLine +
                "AddEvent 2012-03-31T23:59:58 | C# exam (again) - 220784" + Environment.NewLine +
                "AddEvent 2001-01-01T10:30:00 | EXAM | at home" + Environment.NewLine +
                "AddEvent 2001-01-01T10:30:03 | party Lora - 198672 |  - 235165" + Environment.NewLine +
                "AddEvent 2001-01-01T11:00:00 | Rock party | home" + Environment.NewLine +
                "AddEvent 2001-01-01T16:00:00 | party Lora | Varna" + Environment.NewLine +
                "AddEvent 2001-01-01T10:00:00 | Exam | sofia - 37482" + Environment.NewLine +
                "AddEvent 2001-01-01T22:00:00 | Rock party" + Environment.NewLine +
                "AddEvent 2000-01-01T00:00:00 | Rock party" + Environment.NewLine +
                "AddEvent 2001-01-01T22:00:00 | C# course" + Environment.NewLine +
                "AddEvent 2019-01-01T00:00:00 | Exam" + Environment.NewLine +
                "AddEvent 2001-01-01T22:30:00 | Party LORA | sofia" + Environment.NewLine +
                "AddEvent 2001-01-01T11:00:00 | exam | at school" + Environment.NewLine +
                "AddEvent 2001-01-01T12:00:00 | party | Kaspichan" + Environment.NewLine +
                "AddEvent 2001-01-01T11:30:00 | party Kiro - 518671" + Environment.NewLine +
                "AddEvent 2001-01-01T22:00:00 | party Kiro | Kaspichan" + Environment.NewLine +
                "AddEvent 2001-01-01T00:00:00 | Exam | at school" + Environment.NewLine +
                "AddEvent 2001-01-01T10:30:03 | Chalga party - 974464 | at school - 479574" + Environment.NewLine +
                "AddEvent 2019-01-01T00:00:00 | exam | Kaspichan" + Environment.NewLine +
                "AddEvent 2001-01-01T10:30:01 | party Kiro | Home" + Environment.NewLine +
                "AddEvent 2001-01-01T11:00:00 | Exam - 350394" + Environment.NewLine +
                "AddEvent 2001-01-01T10:30:02 | Exam - 692 | at school" + Environment.NewLine +
                "AddEvent 2001-01-01T11:30:00 | Exam - 423288 | Varna - 367061" + Environment.NewLine +
                "AddEvent 2000-01-01T00:00:00 | Exam - 470189" + Environment.NewLine +
                "AddEvent 2001-01-01T22:30:00 | EXAM" + Environment.NewLine +
                "AddEvent 2001-01-01T10:30:00 | C# exam (again) | at school - 376932" + Environment.NewLine +
                "AddEvent 2019-01-01T00:00:00 | party" + Environment.NewLine +
                "AddEvent 2001-01-01T10:30:02 | Party LORA | sofia" + Environment.NewLine +
                "AddEvent 2001-01-01T20:00:00 | party Kiro | Sofia" + Environment.NewLine +
                "AddEvent 2001-01-01T10:30:02 | C# course - 138323 | Telerik academy" + Environment.NewLine +
                "AddEvent 2012-03-31T23:59:58 | party" + Environment.NewLine +
                "AddEvent 2012-03-31T23:59:59 | C# exam (again)" + Environment.NewLine +
                "AddEvent 2001-01-01T22:00:00 | PARTY - 278108" + Environment.NewLine +
                "AddEvent 2001-01-01T10:30:03 | Chalga party" + Environment.NewLine +
                "AddEvent 2001-01-01T20:00:00 | party Lora" + Environment.NewLine +
                "AddEvent 2001-02-01T00:00:00 | party" + Environment.NewLine +
                "AddEvent 2012-03-31T23:59:57 | Rock party - 407026 | home - 681328" + Environment.NewLine +
                "AddEvent 2001-01-01T20:00:00 | Party LORA - 599440" + Environment.NewLine +
                "AddEvent 2001-01-01T16:00:00 | exam |  - 264116" + Environment.NewLine +
                "AddEvent 2012-03-31T23:59:58 | C# exam (again) - 468063 | Kaspichan" + Environment.NewLine +
                "AddEvent 2001-01-01T10:30:03 | exam | at school" + Environment.NewLine +
                "AddEvent 2001-01-01T10:00:00 | Chalga party | at home" + Environment.NewLine +
                "AddEvent 2012-03-31T23:59:59 | C# exam (again) - 979458 |  - 922870" + Environment.NewLine +
                "AddEvent 2012-03-31T23:59:58 | Exam | telerik academy" + Environment.NewLine +
                "AddEvent 2001-01-01T16:00:00 | exam" + Environment.NewLine +
                "AddEvent 2001-01-01T10:00:00 | Exam | Telerik academy" + Environment.NewLine +
                "AddEvent 2001-01-01T12:00:00 | Chalga party - 406733 | telerik academy" + Environment.NewLine +
                "AddEvent 2001-01-01T10:30:03 | party Lora - 158117 | Kaspichan" + Environment.NewLine +
                "AddEvent 2000-01-01T00:00:00 | Rock party" + Environment.NewLine +
                "AddEvent 2012-03-31T23:59:58 | Exam" + Environment.NewLine +
                "AddEvent 2001-01-01T22:00:00 | C# course" + Environment.NewLine +
                "AddEvent 2001-01-01T10:30:01 | party Lora - 488100" + Environment.NewLine +
                "AddEvent 2001-01-01T10:30:03 | Party LORA" + Environment.NewLine +
                "AddEvent 2001-01-01T00:00:00 | party - 461156 | Kaspichan" + Environment.NewLine +
                "AddEvent 2001-01-01T20:00:00 | Chalga party - 70000 | at home" + Environment.NewLine +
                "AddEvent 2001-01-01T12:00:00 | C# exam (again)" + Environment.NewLine +
                "AddEvent 2001-01-01T22:30:00 | C# course - 853264 | Sofia" + Environment.NewLine +
                "AddEvent 2012-03-31T23:59:58 | party | Kaspichan" + Environment.NewLine +
                "AddEvent 2001-01-01T11:30:00 | Rock party" + Environment.NewLine +
                "AddEvent 2001-01-01T22:30:00 | exam - 804175 | Telerik academy" + Environment.NewLine +
                "AddEvent 2001-01-01T11:00:00 | C# course | sofia" + Environment.NewLine +
                "AddEvent 2001-01-01T10:30:03 | party Lora" + Environment.NewLine +
                "AddEvent 2012-03-31T23:59:58 | Party LORA | Kaspichan" + Environment.NewLine +
                "AddEvent 2001-01-01T11:00:00 | Chalga party - 679007" + Environment.NewLine +
                "AddEvent 2001-01-01T11:30:00 | PARTY |  - 465511" + Environment.NewLine +
                "ListEvents 2001-01-01T10:30:01 | 7" + Environment.NewLine +
                "ListEvents 2001-01-01T22:00:00 | 3" + Environment.NewLine +
                "ListEvents 2001-01-01T11:00:00 | 5" + Environment.NewLine +
                "ListEvents 2001-01-01T10:30:01 | 19" + Environment.NewLine +
                "ListEvents 2001-01-01T00:00:00 | 14" + Environment.NewLine +
                "AddEvent 2001-01-01T10:30:03 | party Kiro" + Environment.NewLine +
                "AddEvent 2019-01-01T00:00:00 | C# exam (again) | at home" + Environment.NewLine +
                "AddEvent 2001-01-01T10:00:00 | party Kiro - 645831 |  - 599812" + Environment.NewLine +
                "AddEvent 2001-02-01T00:00:00 | Exam | Plovdiv" + Environment.NewLine +
                "AddEvent 2001-02-01T00:00:00 | party Lora" + Environment.NewLine +
                "AddEvent 2001-01-01T00:00:00 | Exam | Home" + Environment.NewLine +
                "AddEvent 2012-03-31T23:59:58 | party Kiro - 744173 | Varna - 771418" + Environment.NewLine +
                "AddEvent 2001-01-01T10:30:01 | EXAM - 197258" + Environment.NewLine +
                "AddEvent 2001-01-01T10:30:00 | C# exam (again) | sofia" + Environment.NewLine +
                "AddEvent 2012-03-31T23:59:59 | exam" + Environment.NewLine +
                "AddEvent 2001-01-01T16:00:00 | party Lora" + Environment.NewLine +
                "AddEvent 2019-01-01T00:00:00 | C# course |  - 531989" + Environment.NewLine +
                "AddEvent 2001-01-01T10:00:00 | party | Home" + Environment.NewLine +
                "AddEvent 2000-01-01T00:00:00 | Party LORA | Telerik academy - 14832" + Environment.NewLine +
                "AddEvent 2001-01-01T22:00:00 | PARTY | home" + Environment.NewLine +
                "AddEvent 2001-01-01T22:30:00 | Party LORA - 986290 | home" + Environment.NewLine +
                "AddEvent 2001-01-01T22:00:00 | Party LORA - 791305" + Environment.NewLine +
                "AddEvent 2001-02-01T00:00:00 | Party LORA - 85232" + Environment.NewLine +
                "AddEvent 2001-01-01T22:00:00 | party | sofia" + Environment.NewLine +
                "AddEvent 2001-01-01T11:00:00 | party Kiro - 384003 | telerik academy" + Environment.NewLine +
                "AddEvent 2019-01-01T00:00:00 | exam - 59365" + Environment.NewLine +
                "AddEvent 2001-01-01T10:30:02 | PARTY" + Environment.NewLine +
                "AddEvent 2001-01-01T12:00:00 | party Lora - 243949" + Environment.NewLine +
                "AddEvent 2001-01-01T10:30:02 | Rock party | at home" + Environment.NewLine +
                "AddEvent 2001-01-01T10:30:02 | C# course" + Environment.NewLine +
                "AddEvent 2001-01-01T00:00:00 | PARTY - 352449 |  - 408337" + Environment.NewLine +
                "AddEvent 2001-01-01T11:00:00 | Rock party | Home - 397026" + Environment.NewLine +
                "AddEvent 2001-01-01T10:30:02 | Rock party" + Environment.NewLine +
                "AddEvent 2001-01-01T10:30:01 | party Lora | Kaspichan" + Environment.NewLine +
                "AddEvent 2001-01-01T10:30:00 | Party LORA | Sofia" + Environment.NewLine +
                "AddEvent 2001-01-01T10:30:00 | Chalga party | at home - 222820" + Environment.NewLine +
                "AddEvent 2001-01-01T12:00:00 | exam" + Environment.NewLine +
                "AddEvent 2019-01-01T00:00:00 | Chalga party | Varna" + Environment.NewLine +
                "AddEvent 2019-01-01T00:00:00 | party - 416966" + Environment.NewLine +
                "AddEvent 2012-03-31T23:59:57 | EXAM - 194681 | at school" + Environment.NewLine +
                "AddEvent 2001-01-01T11:30:00 | Party LORA | home" + Environment.NewLine +
                "AddEvent 2012-03-31T23:59:58 | C# exam (again) - 220784" + Environment.NewLine +
                "AddEvent 2001-01-01T10:30:00 | EXAM | at home" + Environment.NewLine +
                "AddEvent 2001-01-01T10:30:03 | party Lora - 198672 |  - 235165" + Environment.NewLine +
                "AddEvent 2001-01-01T11:00:00 | Rock party | home" + Environment.NewLine +
                "AddEvent 2001-01-01T16:00:00 | party Lora | Varna" + Environment.NewLine +
                "AddEvent 2001-01-01T10:00:00 | Exam | sofia - 37482" + Environment.NewLine +
                "AddEvent 2001-01-01T22:00:00 | Rock party" + Environment.NewLine +
                "AddEvent 2000-01-01T00:00:00 | Rock party" + Environment.NewLine +
                "AddEvent 2001-01-01T22:00:00 | C# course" + Environment.NewLine +
                "AddEvent 2019-01-01T00:00:00 | Exam" + Environment.NewLine +
                "AddEvent 2001-01-01T22:30:00 | Party LORA | sofia" + Environment.NewLine +
                "AddEvent 2001-01-01T11:00:00 | exam | at school" + Environment.NewLine +
                "AddEvent 2001-01-01T12:00:00 | party | Kaspichan" + Environment.NewLine +
                "AddEvent 2001-01-01T11:30:00 | party Kiro - 518671" + Environment.NewLine +
                "AddEvent 2001-01-01T22:00:00 | party Kiro | Kaspichan" + Environment.NewLine +
                "AddEvent 2001-01-01T00:00:00 | Exam | at school" + Environment.NewLine +
                "AddEvent 2001-01-01T10:30:03 | Chalga party - 974464 | at school - 479574" + Environment.NewLine +
                "AddEvent 2019-01-01T00:00:00 | exam | Kaspichan" + Environment.NewLine +
                "AddEvent 2001-01-01T10:30:01 | party Kiro | Home" + Environment.NewLine +
                "AddEvent 2001-01-01T11:00:00 | Exam - 350394" + Environment.NewLine +
                "AddEvent 2001-01-01T10:30:02 | Exam - 692 | at school" + Environment.NewLine +
                "AddEvent 2001-01-01T11:30:00 | Exam - 423288 | Varna - 367061" + Environment.NewLine +
                "AddEvent 2000-01-01T00:00:00 | Exam - 470189" + Environment.NewLine +
                "AddEvent 2001-01-01T22:30:00 | EXAM" + Environment.NewLine +
                "AddEvent 2001-01-01T10:30:00 | C# exam (again) | at school - 376932" + Environment.NewLine +
                "AddEvent 2019-01-01T00:00:00 | party" + Environment.NewLine +
                "AddEvent 2001-01-01T10:30:02 | Party LORA | sofia" + Environment.NewLine +
                "AddEvent 2001-01-01T20:00:00 | party Kiro | Sofia" + Environment.NewLine +
                "AddEvent 2001-01-01T10:30:02 | C# course - 138323 | Telerik academy" + Environment.NewLine +
                "AddEvent 2012-03-31T23:59:58 | party" + Environment.NewLine +
                "AddEvent 2012-03-31T23:59:59 | C# exam (again)" + Environment.NewLine +
                "AddEvent 2001-01-01T22:00:00 | PARTY - 278108" + Environment.NewLine +
                "AddEvent 2001-01-01T10:30:03 | Chalga party" + Environment.NewLine +
                "AddEvent 2001-01-01T20:00:00 | party Lora" + Environment.NewLine +
                "AddEvent 2001-02-01T00:00:00 | party" + Environment.NewLine +
                "AddEvent 2012-03-31T23:59:57 | Rock party - 407026 | home - 681328" + Environment.NewLine +
                "AddEvent 2001-01-01T20:00:00 | Party LORA - 599440" + Environment.NewLine +
                "AddEvent 2001-01-01T16:00:00 | exam |  - 264116" + Environment.NewLine +
                "AddEvent 2012-03-31T23:59:58 | C# exam (again) - 468063 | Kaspichan" + Environment.NewLine +
                "AddEvent 2001-01-01T10:30:03 | exam | at school" + Environment.NewLine +
                "AddEvent 2001-01-01T10:00:00 | Chalga party | at home" + Environment.NewLine +
                "AddEvent 2012-03-31T23:59:59 | C# exam (again) - 979458 |  - 922870" + Environment.NewLine +
                "AddEvent 2012-03-31T23:59:58 | Exam | telerik academy" + Environment.NewLine +
                "AddEvent 2001-01-01T16:00:00 | exam" + Environment.NewLine +
                "AddEvent 2001-01-01T10:00:00 | Exam | Telerik academy" + Environment.NewLine +
                "AddEvent 2001-01-01T12:00:00 | Chalga party - 406733 | telerik academy" + Environment.NewLine +
                "AddEvent 2001-01-01T10:30:03 | party Lora - 158117 | Kaspichan" + Environment.NewLine +
                "AddEvent 2000-01-01T00:00:00 | Rock party" + Environment.NewLine +
                "AddEvent 2012-03-31T23:59:58 | Exam" + Environment.NewLine +
                "AddEvent 2001-01-01T22:00:00 | C# course" + Environment.NewLine +
                "AddEvent 2001-01-01T10:30:01 | party Lora - 488100" + Environment.NewLine +
                "AddEvent 2001-01-01T10:30:03 | Party LORA" + Environment.NewLine +
                "AddEvent 2001-01-01T00:00:00 | party - 461156 | Kaspichan" + Environment.NewLine +
                "AddEvent 2001-01-01T20:00:00 | Chalga party - 70000 | at home" + Environment.NewLine +
                "AddEvent 2001-01-01T12:00:00 | C# exam (again)" + Environment.NewLine +
                "AddEvent 2001-01-01T22:30:00 | C# course - 853264 | Sofia" + Environment.NewLine +
                "AddEvent 2012-03-31T23:59:58 | party | Kaspichan" + Environment.NewLine +
                "AddEvent 2001-01-01T11:30:00 | Rock party" + Environment.NewLine +
                "AddEvent 2001-01-01T22:30:00 | exam - 804175 | Telerik academy" + Environment.NewLine +
                "AddEvent 2001-01-01T11:00:00 | C# course | sofia" + Environment.NewLine +
                "AddEvent 2001-01-01T10:30:03 | party Lora" + Environment.NewLine +
                "AddEvent 2012-03-31T23:59:58 | Party LORA | Kaspichan" + Environment.NewLine +
                "AddEvent 2001-01-01T11:00:00 | Chalga party - 679007" + Environment.NewLine +
                "AddEvent 2001-01-01T11:30:00 | PARTY |  - 465511" + Environment.NewLine +
                "ListEvents 2001-01-01T10:30:01 | 7" + Environment.NewLine +
                "ListEvents 2001-01-01T22:00:00 | 3" + Environment.NewLine +
                "ListEvents 2001-01-01T11:00:00 | 5" + Environment.NewLine +
                "ListEvents 2001-01-01T10:30:01 | 19" + Environment.NewLine +
                "ListEvents 2001-01-01T00:00:00 | 14" + Environment.NewLine +
                "DeleteEvents party Lora" + Environment.NewLine +
                "DeleteEvents Party LORA - 500968" + Environment.NewLine +
                "DeleteEvents Rock party" + Environment.NewLine +
                "DeleteEvents PARTY" + Environment.NewLine +
                "DeleteEvents C# exam (again) - 581288" + Environment.NewLine +
                "ListEvents 2012-03-31T23:59:57 | 6" + Environment.NewLine +
                "ListEvents 2012-03-31T23:59:59 | 2" + Environment.NewLine +
                "ListEvents 2001-02-01T00:00:00 | 1" + Environment.NewLine +
                "ListEvents 2012-03-31T23:59:59 | 1" + Environment.NewLine +
                "ListEvents 2001-01-01T10:30:03 | 13" + Environment.NewLine +
                "AddEvent 2001-01-01T10:00:00 | party Kiro | sofia" + Environment.NewLine +
                "AddEvent 2001-02-01T00:00:00 | Chalga party | Plovdiv" + Environment.NewLine +
                "AddEvent 2001-01-01T00:00:00 | Rock party | Telerik academy - 799630" + Environment.NewLine +
                "AddEvent 2001-01-01T11:00:00 | Rock party | Home" + Environment.NewLine +
                "AddEvent 2000-01-01T00:00:00 | Exam" + Environment.NewLine +
                "AddEvent 2001-01-01T11:30:00 | Exam | at home - 774892" + Environment.NewLine +
                "AddEvent 2001-01-01T20:00:00 | C# course | Kaspichan - 334693" + Environment.NewLine +
                "AddEvent 2001-01-01T10:30:01 | party | Home" + Environment.NewLine +
                "AddEvent 2012-03-31T23:59:58 | Exam | sofia" + Environment.NewLine +
                "AddEvent 2001-01-01T16:00:00 | Party LORA | at school" + Environment.NewLine +
                "ListEvents 2012-03-31T23:59:59 | 11" + Environment.NewLine +
                "ListEvents 2001-01-01T10:30:02 | 8" + Environment.NewLine +
                "ListEvents 2001-01-01T10:30:01 | 4" + Environment.NewLine +
                "ListEvents 2001-01-01T10:30:03 | 16" + Environment.NewLine +
                "ListEvents 2012-03-31T23:59:59 | 10" + Environment.NewLine +
                "AddEvent 2001-01-01T10:30:03 | party Kiro" + Environment.NewLine +
                "AddEvent 2019-01-01T00:00:00 | C# exam (again) | at home" + Environment.NewLine +
                "AddEvent 2001-01-01T10:00:00 | party Kiro - 645831 |  - 599812" + Environment.NewLine +
                "AddEvent 2001-02-01T00:00:00 | Exam | Plovdiv" + Environment.NewLine +
                "AddEvent 2001-02-01T00:00:00 | party Lora" + Environment.NewLine +
                "AddEvent 2001-01-01T00:00:00 | Exam | Home" + Environment.NewLine +
                "AddEvent 2012-03-31T23:59:58 | party Kiro - 744173 | Varna - 771418" + Environment.NewLine +
                "AddEvent 2001-01-01T10:30:01 | EXAM - 197258" + Environment.NewLine +
                "AddEvent 2001-01-01T10:30:00 | C# exam (again) | sofia" + Environment.NewLine +
                "AddEvent 2012-03-31T23:59:59 | exam" + Environment.NewLine +
                "AddEvent 2001-01-01T16:00:00 | party Lora" + Environment.NewLine +
                "AddEvent 2019-01-01T00:00:00 | C# course |  - 531989" + Environment.NewLine +
                "AddEvent 2001-01-01T10:00:00 | party | Home" + Environment.NewLine +
                "AddEvent 2000-01-01T00:00:00 | Party LORA | Telerik academy - 14832" + Environment.NewLine +
                "AddEvent 2001-01-01T22:00:00 | PARTY | home" + Environment.NewLine +
                "AddEvent 2001-01-01T22:30:00 | Party LORA - 986290 | home" + Environment.NewLine +
                "AddEvent 2001-01-01T22:00:00 | Party LORA - 791305" + Environment.NewLine +
                "AddEvent 2001-02-01T00:00:00 | Party LORA - 85232" + Environment.NewLine +
                "AddEvent 2001-01-01T22:00:00 | party | sofia" + Environment.NewLine +
                "AddEvent 2001-01-01T11:00:00 | party Kiro - 384003 | telerik academy" + Environment.NewLine +
                "AddEvent 2019-01-01T00:00:00 | exam - 59365" + Environment.NewLine +
                "AddEvent 2001-01-01T10:30:02 | PARTY" + Environment.NewLine +
                "AddEvent 2001-01-01T12:00:00 | party Lora - 243949" + Environment.NewLine +
                "AddEvent 2001-01-01T10:30:02 | Rock party | at home" + Environment.NewLine +
                "AddEvent 2001-01-01T10:30:02 | C# course" + Environment.NewLine +
                "AddEvent 2001-01-01T00:00:00 | PARTY - 352449 |  - 408337" + Environment.NewLine +
                "AddEvent 2001-01-01T11:00:00 | Rock party | Home - 397026" + Environment.NewLine +
                "AddEvent 2001-01-01T10:30:02 | Rock party" + Environment.NewLine +
                "AddEvent 2001-01-01T10:30:01 | party Lora | Kaspichan" + Environment.NewLine +
                "AddEvent 2001-01-01T10:30:00 | Party LORA | Sofia" + Environment.NewLine +
                "AddEvent 2001-01-01T10:30:00 | Chalga party | at home - 222820" + Environment.NewLine +
                "AddEvent 2001-01-01T12:00:00 | exam" + Environment.NewLine +
                "AddEvent 2019-01-01T00:00:00 | Chalga party | Varna" + Environment.NewLine +
                "AddEvent 2019-01-01T00:00:00 | party - 416966" + Environment.NewLine +
                "AddEvent 2012-03-31T23:59:57 | EXAM - 194681 | at school" + Environment.NewLine +
                "AddEvent 2001-01-01T11:30:00 | Party LORA | home" + Environment.NewLine +
                "AddEvent 2012-03-31T23:59:58 | C# exam (again) - 220784" + Environment.NewLine +
                "AddEvent 2001-01-01T10:30:00 | EXAM | at home" + Environment.NewLine +
                "AddEvent 2001-01-01T10:30:03 | party Lora - 198672 |  - 235165" + Environment.NewLine +
                "AddEvent 2001-01-01T11:00:00 | Rock party | home" + Environment.NewLine +
                "AddEvent 2001-01-01T16:00:00 | party Lora | Varna" + Environment.NewLine +
                "AddEvent 2001-01-01T10:00:00 | Exam | sofia - 37482" + Environment.NewLine +
                "AddEvent 2001-01-01T22:00:00 | Rock party" + Environment.NewLine +
                "AddEvent 2000-01-01T00:00:00 | Rock party" + Environment.NewLine +
                "AddEvent 2001-01-01T22:00:00 | C# course" + Environment.NewLine +
                "AddEvent 2019-01-01T00:00:00 | Exam" + Environment.NewLine +
                "AddEvent 2001-01-01T22:30:00 | Party LORA | sofia" + Environment.NewLine +
                "AddEvent 2001-01-01T11:00:00 | exam | at school" + Environment.NewLine +
                "AddEvent 2001-01-01T12:00:00 | party | Kaspichan" + Environment.NewLine +
                "AddEvent 2001-01-01T11:30:00 | party Kiro - 518671" + Environment.NewLine +
                "AddEvent 2001-01-01T22:00:00 | party Kiro | Kaspichan" + Environment.NewLine +
                "AddEvent 2001-01-01T00:00:00 | Exam | at school" + Environment.NewLine +
                "AddEvent 2001-01-01T10:30:03 | Chalga party - 974464 | at school - 479574" + Environment.NewLine +
                "AddEvent 2019-01-01T00:00:00 | exam | Kaspichan" + Environment.NewLine +
                "AddEvent 2001-01-01T10:30:01 | party Kiro | Home" + Environment.NewLine +
                "AddEvent 2001-01-01T11:00:00 | Exam - 350394" + Environment.NewLine +
                "AddEvent 2001-01-01T10:30:02 | Exam - 692 | at school" + Environment.NewLine +
                "AddEvent 2001-01-01T11:30:00 | Exam - 423288 | Varna - 367061" + Environment.NewLine +
                "AddEvent 2000-01-01T00:00:00 | Exam - 470189" + Environment.NewLine +
                "AddEvent 2001-01-01T22:30:00 | EXAM" + Environment.NewLine +
                "AddEvent 2001-01-01T10:30:00 | C# exam (again) | at school - 376932" + Environment.NewLine +
                "AddEvent 2019-01-01T00:00:00 | party" + Environment.NewLine +
                "AddEvent 2001-01-01T10:30:02 | Party LORA | sofia" + Environment.NewLine +
                "AddEvent 2001-01-01T20:00:00 | party Kiro | Sofia" + Environment.NewLine +
                "AddEvent 2001-01-01T10:30:02 | C# course - 138323 | Telerik academy" + Environment.NewLine +
                "AddEvent 2012-03-31T23:59:58 | party" + Environment.NewLine +
                "AddEvent 2012-03-31T23:59:59 | C# exam (again)" + Environment.NewLine +
                "AddEvent 2001-01-01T22:00:00 | PARTY - 278108" + Environment.NewLine +
                "AddEvent 2001-01-01T10:30:03 | Chalga party" + Environment.NewLine +
                "AddEvent 2001-01-01T20:00:00 | party Lora" + Environment.NewLine +
                "AddEvent 2001-02-01T00:00:00 | party" + Environment.NewLine +
                "AddEvent 2012-03-31T23:59:57 | Rock party - 407026 | home - 681328" + Environment.NewLine +
                "AddEvent 2001-01-01T20:00:00 | Party LORA - 599440" + Environment.NewLine +
                "AddEvent 2001-01-01T16:00:00 | exam |  - 264116" + Environment.NewLine +
                "AddEvent 2012-03-31T23:59:58 | C# exam (again) - 468063 | Kaspichan" + Environment.NewLine +
                "AddEvent 2001-01-01T10:30:03 | exam | at school" + Environment.NewLine +
                "AddEvent 2001-01-01T10:00:00 | Chalga party | at home" + Environment.NewLine +
                "AddEvent 2012-03-31T23:59:59 | C# exam (again) - 979458 |  - 922870" + Environment.NewLine +
                "AddEvent 2012-03-31T23:59:58 | Exam | telerik academy" + Environment.NewLine +
                "AddEvent 2001-01-01T16:00:00 | exam" + Environment.NewLine +
                "AddEvent 2001-01-01T10:00:00 | Exam | Telerik academy" + Environment.NewLine +
                "AddEvent 2001-01-01T12:00:00 | Chalga party - 406733 | telerik academy" + Environment.NewLine +
                "AddEvent 2001-01-01T10:30:03 | party Lora - 158117 | Kaspichan" + Environment.NewLine +
                "AddEvent 2000-01-01T00:00:00 | Rock party" + Environment.NewLine +
                "AddEvent 2012-03-31T23:59:58 | Exam" + Environment.NewLine +
                "AddEvent 2001-01-01T22:00:00 | C# course" + Environment.NewLine +
                "AddEvent 2001-01-01T10:30:01 | party Lora - 488100" + Environment.NewLine +
                "AddEvent 2001-01-01T10:30:03 | Party LORA" + Environment.NewLine +
                "AddEvent 2001-01-01T00:00:00 | party - 461156 | Kaspichan" + Environment.NewLine +
                "AddEvent 2001-01-01T20:00:00 | Chalga party - 70000 | at home" + Environment.NewLine +
                "AddEvent 2001-01-01T12:00:00 | C# exam (again)" + Environment.NewLine +
                "AddEvent 2001-01-01T22:30:00 | C# course - 853264 | Sofia" + Environment.NewLine +
                "AddEvent 2012-03-31T23:59:58 | party | Kaspichan" + Environment.NewLine +
                "AddEvent 2001-01-01T11:30:00 | Rock party" + Environment.NewLine +
                "AddEvent 2001-01-01T22:30:00 | exam - 804175 | Telerik academy" + Environment.NewLine +
                "AddEvent 2001-01-01T11:00:00 | C# course | sofia" + Environment.NewLine +
                "AddEvent 2001-01-01T10:30:03 | party Lora" + Environment.NewLine +
                "AddEvent 2012-03-31T23:59:58 | Party LORA | Kaspichan" + Environment.NewLine +
                "AddEvent 2001-01-01T11:00:00 | Chalga party - 679007" + Environment.NewLine +
                "AddEvent 2001-01-01T11:30:00 | PARTY |  - 465511" + Environment.NewLine +
                "ListEvents 2001-01-01T10:30:01 | 7" + Environment.NewLine +
                "ListEvents 2001-01-01T22:00:00 | 3" + Environment.NewLine +
                "ListEvents 2001-01-01T11:00:00 | 5" + Environment.NewLine +
                "ListEvents 2001-01-01T10:30:01 | 19" + Environment.NewLine +
                "ListEvents 2001-01-01T00:00:00 | 14" + Environment.NewLine +
                "AddEvent 2001-01-01T10:30:03 | party Kiro" + Environment.NewLine +
                "AddEvent 2019-01-01T00:00:00 | C# exam (again) | at home" + Environment.NewLine +
                "AddEvent 2001-01-01T10:00:00 | party Kiro - 645831 |  - 599812" + Environment.NewLine +
                "AddEvent 2001-02-01T00:00:00 | Exam | Plovdiv" + Environment.NewLine +
                "AddEvent 2001-02-01T00:00:00 | party Lora" + Environment.NewLine +
                "AddEvent 2001-01-01T00:00:00 | Exam | Home" + Environment.NewLine +
                "AddEvent 2012-03-31T23:59:58 | party Kiro - 744173 | Varna - 771418" + Environment.NewLine +
                "AddEvent 2001-01-01T10:30:01 | EXAM - 197258" + Environment.NewLine +
                "AddEvent 2001-01-01T10:30:00 | C# exam (again) | sofia" + Environment.NewLine +
                "AddEvent 2012-03-31T23:59:59 | exam" + Environment.NewLine +
                "AddEvent 2001-01-01T16:00:00 | party Lora" + Environment.NewLine +
                "AddEvent 2019-01-01T00:00:00 | C# course |  - 531989" + Environment.NewLine +
                "AddEvent 2001-01-01T10:00:00 | party | Home" + Environment.NewLine +
                "AddEvent 2000-01-01T00:00:00 | Party LORA | Telerik academy - 14832" + Environment.NewLine +
                "AddEvent 2001-01-01T22:00:00 | PARTY | home" + Environment.NewLine +
                "AddEvent 2001-01-01T22:30:00 | Party LORA - 986290 | home" + Environment.NewLine +
                "AddEvent 2001-01-01T22:00:00 | Party LORA - 791305" + Environment.NewLine +
                "AddEvent 2001-02-01T00:00:00 | Party LORA - 85232" + Environment.NewLine +
                "AddEvent 2001-01-01T22:00:00 | party | sofia" + Environment.NewLine +
                "AddEvent 2001-01-01T11:00:00 | party Kiro - 384003 | telerik academy" + Environment.NewLine +
                "AddEvent 2019-01-01T00:00:00 | exam - 59365" + Environment.NewLine +
                "AddEvent 2001-01-01T10:30:02 | PARTY" + Environment.NewLine +
                "AddEvent 2001-01-01T12:00:00 | party Lora - 243949" + Environment.NewLine +
                "AddEvent 2001-01-01T10:30:02 | Rock party | at home" + Environment.NewLine +
                "AddEvent 2001-01-01T10:30:02 | C# course" + Environment.NewLine +
                "AddEvent 2001-01-01T00:00:00 | PARTY - 352449 |  - 408337" + Environment.NewLine +
                "AddEvent 2001-01-01T11:00:00 | Rock party | Home - 397026" + Environment.NewLine +
                "AddEvent 2001-01-01T10:30:02 | Rock party" + Environment.NewLine +
                "AddEvent 2001-01-01T10:30:01 | party Lora | Kaspichan" + Environment.NewLine +
                "AddEvent 2001-01-01T10:30:00 | Party LORA | Sofia" + Environment.NewLine +
                "AddEvent 2001-01-01T10:30:00 | Chalga party | at home - 222820" + Environment.NewLine +
                "AddEvent 2001-01-01T12:00:00 | exam" + Environment.NewLine +
                "AddEvent 2019-01-01T00:00:00 | Chalga party | Varna" + Environment.NewLine +
                "AddEvent 2019-01-01T00:00:00 | party - 416966" + Environment.NewLine +
                "AddEvent 2012-03-31T23:59:57 | EXAM - 194681 | at school" + Environment.NewLine +
                "AddEvent 2001-01-01T11:30:00 | Party LORA | home" + Environment.NewLine +
                "AddEvent 2012-03-31T23:59:58 | C# exam (again) - 220784" + Environment.NewLine +
                "AddEvent 2001-01-01T10:30:00 | EXAM | at home" + Environment.NewLine +
                "AddEvent 2001-01-01T10:30:03 | party Lora - 198672 |  - 235165" + Environment.NewLine +
                "AddEvent 2001-01-01T11:00:00 | Rock party | home" + Environment.NewLine +
                "AddEvent 2001-01-01T16:00:00 | party Lora | Varna" + Environment.NewLine +
                "AddEvent 2001-01-01T10:00:00 | Exam | sofia - 37482" + Environment.NewLine +
                "AddEvent 2001-01-01T22:00:00 | Rock party" + Environment.NewLine +
                "AddEvent 2000-01-01T00:00:00 | Rock party" + Environment.NewLine +
                "AddEvent 2001-01-01T22:00:00 | C# course" + Environment.NewLine +
                "AddEvent 2019-01-01T00:00:00 | Exam" + Environment.NewLine +
                "AddEvent 2001-01-01T22:30:00 | Party LORA | sofia" + Environment.NewLine +
                "AddEvent 2001-01-01T11:00:00 | exam | at school" + Environment.NewLine +
                "AddEvent 2001-01-01T12:00:00 | party | Kaspichan" + Environment.NewLine +
                "AddEvent 2001-01-01T11:30:00 | party Kiro - 518671" + Environment.NewLine +
                "AddEvent 2001-01-01T22:00:00 | party Kiro | Kaspichan" + Environment.NewLine +
                "AddEvent 2001-01-01T00:00:00 | Exam | at school" + Environment.NewLine +
                "AddEvent 2001-01-01T10:30:03 | Chalga party - 974464 | at school - 479574" + Environment.NewLine +
                "AddEvent 2019-01-01T00:00:00 | exam | Kaspichan" + Environment.NewLine +
                "AddEvent 2001-01-01T10:30:01 | party Kiro | Home" + Environment.NewLine +
                "AddEvent 2001-01-01T11:00:00 | Exam - 350394" + Environment.NewLine +
                "AddEvent 2001-01-01T10:30:02 | Exam - 692 | at school" + Environment.NewLine +
                "AddEvent 2001-01-01T11:30:00 | Exam - 423288 | Varna - 367061" + Environment.NewLine +
                "AddEvent 2000-01-01T00:00:00 | Exam - 470189" + Environment.NewLine +
                "AddEvent 2001-01-01T22:30:00 | EXAM" + Environment.NewLine +
                "AddEvent 2001-01-01T10:30:00 | C# exam (again) | at school - 376932" + Environment.NewLine +
                "AddEvent 2019-01-01T00:00:00 | party" + Environment.NewLine +
                "AddEvent 2001-01-01T10:30:02 | Party LORA | sofia" + Environment.NewLine +
                "AddEvent 2001-01-01T20:00:00 | party Kiro | Sofia" + Environment.NewLine +
                "AddEvent 2001-01-01T10:30:02 | C# course - 138323 | Telerik academy" + Environment.NewLine +
                "AddEvent 2012-03-31T23:59:58 | party" + Environment.NewLine +
                "AddEvent 2012-03-31T23:59:59 | C# exam (again)" + Environment.NewLine +
                "AddEvent 2001-01-01T22:00:00 | PARTY - 278108" + Environment.NewLine +
                "AddEvent 2001-01-01T10:30:03 | Chalga party" + Environment.NewLine +
                "AddEvent 2001-01-01T20:00:00 | party Lora" + Environment.NewLine +
                "AddEvent 2001-02-01T00:00:00 | party" + Environment.NewLine +
                "AddEvent 2012-03-31T23:59:57 | Rock party - 407026 | home - 681328" + Environment.NewLine +
                "AddEvent 2001-01-01T20:00:00 | Party LORA - 599440" + Environment.NewLine +
                "AddEvent 2001-01-01T16:00:00 | exam |  - 264116" + Environment.NewLine +
                "AddEvent 2012-03-31T23:59:58 | C# exam (again) - 468063 | Kaspichan" + Environment.NewLine +
                "AddEvent 2001-01-01T10:30:03 | exam | at school" + Environment.NewLine +
                "AddEvent 2001-01-01T10:00:00 | Chalga party | at home" + Environment.NewLine +
                "AddEvent 2012-03-31T23:59:59 | C# exam (again) - 979458 |  - 922870" + Environment.NewLine +
                "AddEvent 2012-03-31T23:59:58 | Exam | telerik academy" + Environment.NewLine +
                "AddEvent 2001-01-01T16:00:00 | exam" + Environment.NewLine +
                "AddEvent 2001-01-01T10:00:00 | Exam | Telerik academy" + Environment.NewLine +
                "AddEvent 2001-01-01T12:00:00 | Chalga party - 406733 | telerik academy" + Environment.NewLine +
                "AddEvent 2001-01-01T10:30:03 | party Lora - 158117 | Kaspichan" + Environment.NewLine +
                "AddEvent 2000-01-01T00:00:00 | Rock party" + Environment.NewLine +
                "AddEvent 2012-03-31T23:59:58 | Exam" + Environment.NewLine +
                "AddEvent 2001-01-01T22:00:00 | C# course" + Environment.NewLine +
                "AddEvent 2001-01-01T10:30:01 | party Lora - 488100" + Environment.NewLine +
                "AddEvent 2001-01-01T10:30:03 | Party LORA" + Environment.NewLine +
                "AddEvent 2001-01-01T00:00:00 | party - 461156 | Kaspichan" + Environment.NewLine +
                "AddEvent 2001-01-01T20:00:00 | Chalga party - 70000 | at home" + Environment.NewLine +
                "AddEvent 2001-01-01T12:00:00 | C# exam (again)" + Environment.NewLine +
                "AddEvent 2001-01-01T22:30:00 | C# course - 853264 | Sofia" + Environment.NewLine +
                "AddEvent 2012-03-31T23:59:58 | party | Kaspichan" + Environment.NewLine +
                "AddEvent 2001-01-01T11:30:00 | Rock party" + Environment.NewLine +
                "AddEvent 2001-01-01T22:30:00 | exam - 804175 | Telerik academy" + Environment.NewLine +
                "AddEvent 2001-01-01T11:00:00 | C# course | sofia" + Environment.NewLine +
                "AddEvent 2001-01-01T10:30:03 | party Lora" + Environment.NewLine +
                "AddEvent 2012-03-31T23:59:58 | Party LORA | Kaspichan" + Environment.NewLine +
                "AddEvent 2001-01-01T11:00:00 | Chalga party - 679007" + Environment.NewLine +
                "AddEvent 2001-01-01T11:30:00 | PARTY |  - 465511" + Environment.NewLine +
                "ListEvents 2001-01-01T10:30:01 | 7" + Environment.NewLine +
                "ListEvents 2001-01-01T22:00:00 | 3" + Environment.NewLine +
                "ListEvents 2001-01-01T11:00:00 | 5" + Environment.NewLine +
                "ListEvents 2001-01-01T10:30:01 | 19" + Environment.NewLine +
                "ListEvents 2001-01-01T00:00:00 | 14" + Environment.NewLine +
                "DeleteEvents party Lora" + Environment.NewLine +
                "DeleteEvents Party LORA - 500968" + Environment.NewLine +
                "DeleteEvents Rock party" + Environment.NewLine +
                "DeleteEvents PARTY" + Environment.NewLine +
                "DeleteEvents C# exam (again) - 581288" + Environment.NewLine +
                "ListEvents 2012-03-31T23:59:57 | 6" + Environment.NewLine +
                "ListEvents 2012-03-31T23:59:59 | 2" + Environment.NewLine +
                "ListEvents 2001-02-01T00:00:00 | 1" + Environment.NewLine +
                "ListEvents 2012-03-31T23:59:59 | 1" + Environment.NewLine +
                "ListEvents 2001-01-01T10:30:03 | 13" + Environment.NewLine +
                "AddEvent 2001-01-01T10:00:00 | party Kiro | sofia" + Environment.NewLine +
                "AddEvent 2001-02-01T00:00:00 | Chalga party | Plovdiv" + Environment.NewLine +
                "AddEvent 2001-01-01T00:00:00 | Rock party | Telerik academy - 799630" + Environment.NewLine +
                "AddEvent 2001-01-01T11:00:00 | Rock party | Home" + Environment.NewLine +
                "AddEvent 2000-01-01T00:00:00 | Exam" + Environment.NewLine +
                "AddEvent 2001-01-01T11:30:00 | Exam | at home - 774892" + Environment.NewLine +
                "AddEvent 2001-01-01T20:00:00 | C# course | Kaspichan - 334693" + Environment.NewLine +
                "AddEvent 2001-01-01T10:30:01 | party | Home" + Environment.NewLine +
                "AddEvent 2012-03-31T23:59:58 | Exam | sofia" + Environment.NewLine +
                "AddEvent 2001-01-01T16:00:00 | Party LORA | at school" + Environment.NewLine +
                "ListEvents 2012-03-31T23:59:59 | 11" + Environment.NewLine +
                "ListEvents 2001-01-01T10:30:02 | 8" + Environment.NewLine +
                "ListEvents 2001-01-01T10:30:01 | 4" + Environment.NewLine +
                "ListEvents 2001-01-01T10:30:03 | 16" + Environment.NewLine +
                "ListEvents 2012-03-31T23:59:59 | 10" + Environment.NewLine +
                "ListEvents 2001-01-01T00:00:00 | 15" + Environment.NewLine +
                "ListEvents 2019-01-01T00:00:00 | 1" + Environment.NewLine +
                "ListEvents 2001-02-01T00:00:00 | 18" + Environment.NewLine +
                "ListEvents 2001-01-01T10:30:02 | 6" + Environment.NewLine +
                "ListEvents 2019-01-01T00:00:00 | 11" + Environment.NewLine +
                "End" + Environment.NewLine
                );

            string expected =
                "Event added" + Environment.NewLine +
                "Event added" + Environment.NewLine +
                "Event added" + Environment.NewLine +
                "Event added" + Environment.NewLine +
                "Event added" + Environment.NewLine +
                "Event added" + Environment.NewLine +
                "Event added" + Environment.NewLine +
                "Event added" + Environment.NewLine +
                "Event added" + Environment.NewLine +
                "Event added" + Environment.NewLine +
                "Event added" + Environment.NewLine +
                "Event added" + Environment.NewLine +
                "Event added" + Environment.NewLine +
                "Event added" + Environment.NewLine +
                "Event added" + Environment.NewLine +
                "Event added" + Environment.NewLine +
                "Event added" + Environment.NewLine +
                "Event added" + Environment.NewLine +
                "Event added" + Environment.NewLine +
                "Event added" + Environment.NewLine +
                "Event added" + Environment.NewLine +
                "Event added" + Environment.NewLine +
                "Event added" + Environment.NewLine +
                "Event added" + Environment.NewLine +
                "Event added" + Environment.NewLine +
                "Event added" + Environment.NewLine +
                "Event added" + Environment.NewLine +
                "Event added" + Environment.NewLine +
                "Event added" + Environment.NewLine +
                "Event added" + Environment.NewLine +
                "Event added" + Environment.NewLine +
                "Event added" + Environment.NewLine +
                "Event added" + Environment.NewLine +
                "Event added" + Environment.NewLine +
                "Event added" + Environment.NewLine +
                "Event added" + Environment.NewLine +
                "Event added" + Environment.NewLine +
                "Event added" + Environment.NewLine +
                "Event added" + Environment.NewLine +
                "Event added" + Environment.NewLine +
                "Event added" + Environment.NewLine +
                "Event added" + Environment.NewLine +
                "Event added" + Environment.NewLine +
                "Event added" + Environment.NewLine +
                "Event added" + Environment.NewLine +
                "Event added" + Environment.NewLine +
                "Event added" + Environment.NewLine +
                "Event added" + Environment.NewLine +
                "Event added" + Environment.NewLine +
                "Event added" + Environment.NewLine +
                "Event added" + Environment.NewLine +
                "Event added" + Environment.NewLine +
                "Event added" + Environment.NewLine +
                "Event added" + Environment.NewLine +
                "Event added" + Environment.NewLine +
                "Event added" + Environment.NewLine +
                "Event added" + Environment.NewLine +
                "Event added" + Environment.NewLine +
                "Event added" + Environment.NewLine +
                "Event added" + Environment.NewLine +
                "Event added" + Environment.NewLine +
                "Event added" + Environment.NewLine +
                "Event added" + Environment.NewLine +
                "Event added" + Environment.NewLine +
                "Event added" + Environment.NewLine +
                "Event added" + Environment.NewLine +
                "Event added" + Environment.NewLine +
                "Event added" + Environment.NewLine +
                "Event added" + Environment.NewLine +
                "Event added" + Environment.NewLine +
                "Event added" + Environment.NewLine +
                "Event added" + Environment.NewLine +
                "Event added" + Environment.NewLine +
                "Event added" + Environment.NewLine +
                "Event added" + Environment.NewLine +
                "Event added" + Environment.NewLine +
                "Event added" + Environment.NewLine +
                "Event added" + Environment.NewLine +
                "Event added" + Environment.NewLine +
                "Event added" + Environment.NewLine +
                "Event added" + Environment.NewLine +
                "Event added" + Environment.NewLine +
                "Event added" + Environment.NewLine +
                "Event added" + Environment.NewLine +
                "Event added" + Environment.NewLine +
                "Event added" + Environment.NewLine +
                "Event added" + Environment.NewLine +
                "Event added" + Environment.NewLine +
                "Event added" + Environment.NewLine +
                "Event added" + Environment.NewLine +
                "Event added" + Environment.NewLine +
                "Event added" + Environment.NewLine +
                "Event added" + Environment.NewLine +
                "Event added" + Environment.NewLine +
                "Event added" + Environment.NewLine +
                "Event added" + Environment.NewLine +
                "Event added" + Environment.NewLine +
                "Event added" + Environment.NewLine +
                "Event added" + Environment.NewLine +
                "Event added" + Environment.NewLine +
                "2001-01-01T10:30:01 | EXAM - 197258" + Environment.NewLine +
                "2001-01-01T10:30:01 | party Kiro | Home" + Environment.NewLine +
                "2001-01-01T10:30:01 | party Lora | Kaspichan" + Environment.NewLine +
                "2001-01-01T10:30:01 | party Lora - 488100" + Environment.NewLine +
                "2001-01-01T10:30:02 | C# course" + Environment.NewLine +
                "2001-01-01T10:30:02 | C# course - 138323 | Telerik academy" + Environment.NewLine +
                "2001-01-01T10:30:02 | Exam - 692 | at school" + Environment.NewLine +
                "2001-01-01T22:00:00 | C# course" + Environment.NewLine +
                "2001-01-01T22:00:00 | C# course" + Environment.NewLine +
                "2001-01-01T22:00:00 | party | sofia" + Environment.NewLine +
                "2001-01-01T11:00:00 | C# course | sofia" + Environment.NewLine +
                "2001-01-01T11:00:00 | Chalga party - 679007" + Environment.NewLine +
                "2001-01-01T11:00:00 | exam | at school" + Environment.NewLine +
                "2001-01-01T11:00:00 | Exam - 350394" + Environment.NewLine +
                "2001-01-01T11:00:00 | party Kiro - 384003 | telerik academy" + Environment.NewLine +
                "2001-01-01T10:30:01 | EXAM - 197258" + Environment.NewLine +
                "2001-01-01T10:30:01 | party Kiro | Home" + Environment.NewLine +
                "2001-01-01T10:30:01 | party Lora | Kaspichan" + Environment.NewLine +
                "2001-01-01T10:30:01 | party Lora - 488100" + Environment.NewLine +
                "2001-01-01T10:30:02 | C# course" + Environment.NewLine +
                "2001-01-01T10:30:02 | C# course - 138323 | Telerik academy" + Environment.NewLine +
                "2001-01-01T10:30:02 | Exam - 692 | at school" + Environment.NewLine +
                "2001-01-01T10:30:02 | PARTY" + Environment.NewLine +
                "2001-01-01T10:30:02 | Party LORA | sofia" + Environment.NewLine +
                "2001-01-01T10:30:02 | Rock party" + Environment.NewLine +
                "2001-01-01T10:30:02 | Rock party | at home" + Environment.NewLine +
                "2001-01-01T10:30:03 | Chalga party" + Environment.NewLine +
                "2001-01-01T10:30:03 | Chalga party - 974464 | at school - 479574" + Environment.NewLine +
                "2001-01-01T10:30:03 | exam | at school" + Environment.NewLine +
                "2001-01-01T10:30:03 | party Kiro" + Environment.NewLine +
                "2001-01-01T10:30:03 | party Lora" + Environment.NewLine +
                "2001-01-01T10:30:03 | Party LORA" + Environment.NewLine +
                "2001-01-01T10:30:03 | party Lora - 158117 | Kaspichan" + Environment.NewLine +
                "2001-01-01T10:30:03 | party Lora - 198672 | - 235165" + Environment.NewLine +
                "2001-01-01T00:00:00 | Exam | at school" + Environment.NewLine +
                "2001-01-01T00:00:00 | Exam | Home" + Environment.NewLine +
                "2001-01-01T00:00:00 | PARTY - 352449 | - 408337" + Environment.NewLine +
                "2001-01-01T00:00:00 | party - 461156 | Kaspichan" + Environment.NewLine +
                "2001-01-01T10:00:00 | Chalga party | at home" + Environment.NewLine +
                "2001-01-01T10:00:00 | Exam | sofia - 37482" + Environment.NewLine +
                "2001-01-01T10:00:00 | Exam | Telerik academy" + Environment.NewLine +
                "2001-01-01T10:00:00 | party | Home" + Environment.NewLine +
                "2001-01-01T10:00:00 | party Kiro - 645831 | - 599812" + Environment.NewLine +
                "2001-01-01T10:30:00 | C# exam (again) | at school - 376932" + Environment.NewLine +
                "2001-01-01T10:30:00 | C# exam (again) | sofia" + Environment.NewLine +
                "2001-01-01T10:30:00 | Chalga party | at home - 222820" + Environment.NewLine +
                "2001-01-01T10:30:00 | EXAM | at home" + Environment.NewLine +
                "2001-01-01T10:30:00 | Party LORA | Sofia" + Environment.NewLine +
                "Event added" + Environment.NewLine +
                "Event added" + Environment.NewLine +
                "Event added" + Environment.NewLine +
                "Event added" + Environment.NewLine +
                "Event added" + Environment.NewLine +
                "Event added" + Environment.NewLine +
                "Event added" + Environment.NewLine +
                "Event added" + Environment.NewLine +
                "Event added" + Environment.NewLine +
                "Event added" + Environment.NewLine +
                "Event added" + Environment.NewLine +
                "Event added" + Environment.NewLine +
                "Event added" + Environment.NewLine +
                "Event added" + Environment.NewLine +
                "Event added" + Environment.NewLine +
                "Event added" + Environment.NewLine +
                "Event added" + Environment.NewLine +
                "Event added" + Environment.NewLine +
                "Event added" + Environment.NewLine +
                "Event added" + Environment.NewLine +
                "Event added" + Environment.NewLine +
                "Event added" + Environment.NewLine +
                "Event added" + Environment.NewLine +
                "Event added" + Environment.NewLine +
                "Event added" + Environment.NewLine +
                "Event added" + Environment.NewLine +
                "Event added" + Environment.NewLine +
                "Event added" + Environment.NewLine +
                "Event added" + Environment.NewLine +
                "Event added" + Environment.NewLine +
                "Event added" + Environment.NewLine +
                "Event added" + Environment.NewLine +
                "Event added" + Environment.NewLine +
                "Event added" + Environment.NewLine +
                "Event added" + Environment.NewLine +
                "Event added" + Environment.NewLine +
                "Event added" + Environment.NewLine +
                "Event added" + Environment.NewLine +
                "Event added" + Environment.NewLine +
                "Event added" + Environment.NewLine +
                "Event added" + Environment.NewLine +
                "Event added" + Environment.NewLine +
                "Event added" + Environment.NewLine +
                "Event added" + Environment.NewLine +
                "Event added" + Environment.NewLine +
                "Event added" + Environment.NewLine +
                "Event added" + Environment.NewLine +
                "Event added" + Environment.NewLine +
                "Event added" + Environment.NewLine +
                "Event added" + Environment.NewLine +
                "Event added" + Environment.NewLine +
                "Event added" + Environment.NewLine +
                "Event added" + Environment.NewLine +
                "Event added" + Environment.NewLine +
                "Event added" + Environment.NewLine +
                "Event added" + Environment.NewLine +
                "Event added" + Environment.NewLine +
                "Event added" + Environment.NewLine +
                "Event added" + Environment.NewLine +
                "Event added" + Environment.NewLine +
                "Event added" + Environment.NewLine +
                "Event added" + Environment.NewLine +
                "Event added" + Environment.NewLine +
                "Event added" + Environment.NewLine +
                "Event added" + Environment.NewLine +
                "Event added" + Environment.NewLine +
                "Event added" + Environment.NewLine +
                "Event added" + Environment.NewLine +
                "Event added" + Environment.NewLine +
                "Event added" + Environment.NewLine +
                "Event added" + Environment.NewLine +
                "Event added" + Environment.NewLine +
                "Event added" + Environment.NewLine +
                "Event added" + Environment.NewLine +
                "Event added" + Environment.NewLine +
                "Event added" + Environment.NewLine +
                "Event added" + Environment.NewLine +
                "Event added" + Environment.NewLine +
                "Event added" + Environment.NewLine +
                "Event added" + Environment.NewLine +
                "Event added" + Environment.NewLine +
                "Event added" + Environment.NewLine +
                "Event added" + Environment.NewLine +
                "Event added" + Environment.NewLine +
                "Event added" + Environment.NewLine +
                "Event added" + Environment.NewLine +
                "Event added" + Environment.NewLine +
                "Event added" + Environment.NewLine +
                "Event added" + Environment.NewLine +
                "Event added" + Environment.NewLine +
                "Event added" + Environment.NewLine +
                "Event added" + Environment.NewLine +
                "Event added" + Environment.NewLine +
                "Event added" + Environment.NewLine +
                "Event added" + Environment.NewLine +
                "Event added" + Environment.NewLine +
                "Event added" + Environment.NewLine +
                "Event added" + Environment.NewLine +
                "Event added" + Environment.NewLine +
                "Event added" + Environment.NewLine +
                "2001-01-01T10:30:01 | EXAM - 197258" + Environment.NewLine +
                "2001-01-01T10:30:01 | EXAM - 197258" + Environment.NewLine +
                "2001-01-01T10:30:01 | party Kiro | Home" + Environment.NewLine +
                "2001-01-01T10:30:01 | party Kiro | Home" + Environment.NewLine +
                "2001-01-01T10:30:01 | party Lora | Kaspichan" + Environment.NewLine +
                "2001-01-01T10:30:01 | party Lora | Kaspichan" + Environment.NewLine +
                "2001-01-01T10:30:01 | party Lora - 488100" + Environment.NewLine +
                "2001-01-01T22:00:00 | C# course" + Environment.NewLine +
                "2001-01-01T22:00:00 | C# course" + Environment.NewLine +
                "2001-01-01T22:00:00 | C# course" + Environment.NewLine +
                "2001-01-01T11:00:00 | C# course | sofia" + Environment.NewLine +
                "2001-01-01T11:00:00 | C# course | sofia" + Environment.NewLine +
                "2001-01-01T11:00:00 | Chalga party - 679007" + Environment.NewLine +
                "2001-01-01T11:00:00 | Chalga party - 679007" + Environment.NewLine +
                "2001-01-01T11:00:00 | exam | at school" + Environment.NewLine +
                "2001-01-01T10:30:01 | EXAM - 197258" + Environment.NewLine +
                "2001-01-01T10:30:01 | EXAM - 197258" + Environment.NewLine +
                "2001-01-01T10:30:01 | party Kiro | Home" + Environment.NewLine +
                "2001-01-01T10:30:01 | party Kiro | Home" + Environment.NewLine +
                "2001-01-01T10:30:01 | party Lora | Kaspichan" + Environment.NewLine +
                "2001-01-01T10:30:01 | party Lora | Kaspichan" + Environment.NewLine +
                "2001-01-01T10:30:01 | party Lora - 488100" + Environment.NewLine +
                "2001-01-01T10:30:01 | party Lora - 488100" + Environment.NewLine +
                "2001-01-01T10:30:02 | C# course" + Environment.NewLine +
                "2001-01-01T10:30:02 | C# course" + Environment.NewLine +
                "2001-01-01T10:30:02 | C# course - 138323 | Telerik academy" + Environment.NewLine +
                "2001-01-01T10:30:02 | C# course - 138323 | Telerik academy" + Environment.NewLine +
                "2001-01-01T10:30:02 | Exam - 692 | at school" + Environment.NewLine +
                "2001-01-01T10:30:02 | Exam - 692 | at school" + Environment.NewLine +
                "2001-01-01T10:30:02 | PARTY" + Environment.NewLine +
                "2001-01-01T10:30:02 | PARTY" + Environment.NewLine +
                "2001-01-01T10:30:02 | Party LORA | sofia" + Environment.NewLine +
                "2001-01-01T10:30:02 | Party LORA | sofia" + Environment.NewLine +
                "2001-01-01T10:30:02 | Rock party" + Environment.NewLine +
                "2001-01-01T00:00:00 | Exam | at school" + Environment.NewLine +
                "2001-01-01T00:00:00 | Exam | at school" + Environment.NewLine +
                "2001-01-01T00:00:00 | Exam | Home" + Environment.NewLine +
                "2001-01-01T00:00:00 | Exam | Home" + Environment.NewLine +
                "2001-01-01T00:00:00 | PARTY - 352449 | - 408337" + Environment.NewLine +
                "2001-01-01T00:00:00 | PARTY - 352449 | - 408337" + Environment.NewLine +
                "2001-01-01T00:00:00 | party - 461156 | Kaspichan" + Environment.NewLine +
                "2001-01-01T00:00:00 | party - 461156 | Kaspichan" + Environment.NewLine +
                "2001-01-01T10:00:00 | Chalga party | at home" + Environment.NewLine +
                "2001-01-01T10:00:00 | Chalga party | at home" + Environment.NewLine +
                "2001-01-01T10:00:00 | Exam | sofia - 37482" + Environment.NewLine +
                "2001-01-01T10:00:00 | Exam | sofia - 37482" + Environment.NewLine +
                "2001-01-01T10:00:00 | Exam | Telerik academy" + Environment.NewLine +
                "2001-01-01T10:00:00 | Exam | Telerik academy" + Environment.NewLine +
                "26 events deleted" + Environment.NewLine +
                "No events found" + Environment.NewLine +
                "16 events deleted" + Environment.NewLine +
                "20 events deleted" + Environment.NewLine +
                "No events found" + Environment.NewLine +
                "2012-03-31T23:59:57 | EXAM - 194681 | at school" + Environment.NewLine +
                "2012-03-31T23:59:57 | EXAM - 194681 | at school" + Environment.NewLine +
                "2012-03-31T23:59:57 | Rock party - 407026 | home - 681328" + Environment.NewLine +
                "2012-03-31T23:59:57 | Rock party - 407026 | home - 681328" + Environment.NewLine +
                "2012-03-31T23:59:58 | C# exam (again) - 220784" + Environment.NewLine +
                "2012-03-31T23:59:58 | C# exam (again) - 220784" + Environment.NewLine +
                "2012-03-31T23:59:59 | C# exam (again)" + Environment.NewLine +
                "2012-03-31T23:59:59 | C# exam (again)" + Environment.NewLine +
                "2001-02-01T00:00:00 | Exam | Plovdiv" + Environment.NewLine +
                "2012-03-31T23:59:59 | C# exam (again)" + Environment.NewLine +
                "2001-01-01T10:30:03 | Chalga party" + Environment.NewLine +
                "2001-01-01T10:30:03 | Chalga party" + Environment.NewLine +
                "2001-01-01T10:30:03 | Chalga party - 974464 | at school - 479574" + Environment.NewLine +
                "2001-01-01T10:30:03 | Chalga party - 974464 | at school - 479574" + Environment.NewLine +
                "2001-01-01T10:30:03 | exam | at school" + Environment.NewLine +
                "2001-01-01T10:30:03 | exam | at school" + Environment.NewLine +
                "2001-01-01T10:30:03 | party Kiro" + Environment.NewLine +
                "2001-01-01T10:30:03 | party Kiro" + Environment.NewLine +
                "2001-01-01T10:30:03 | party Lora - 158117 | Kaspichan" + Environment.NewLine +
                "2001-01-01T10:30:03 | party Lora - 158117 | Kaspichan" + Environment.NewLine +
                "2001-01-01T10:30:03 | party Lora - 198672 | - 235165" + Environment.NewLine +
                "2001-01-01T10:30:03 | party Lora - 198672 | - 235165" + Environment.NewLine +
                "2001-01-01T11:00:00 | C# course | sofia" + Environment.NewLine +
                "Event added" + Environment.NewLine +
                "Event added" + Environment.NewLine +
                "Event added" + Environment.NewLine +
                "Event added" + Environment.NewLine +
                "Event added" + Environment.NewLine +
                "Event added" + Environment.NewLine +
                "Event added" + Environment.NewLine +
                "Event added" + Environment.NewLine +
                "Event added" + Environment.NewLine +
                "Event added" + Environment.NewLine +
                "2012-03-31T23:59:59 | C# exam (again)" + Environment.NewLine +
                "2012-03-31T23:59:59 | C# exam (again)" + Environment.NewLine +
                "2012-03-31T23:59:59 | C# exam (again) - 979458 | - 922870" + Environment.NewLine +
                "2012-03-31T23:59:59 | C# exam (again) - 979458 | - 922870" + Environment.NewLine +
                "2012-03-31T23:59:59 | exam" + Environment.NewLine +
                "2012-03-31T23:59:59 | exam" + Environment.NewLine +
                "2019-01-01T00:00:00 | C# course | - 531989" + Environment.NewLine +
                "2019-01-01T00:00:00 | C# course | - 531989" + Environment.NewLine +
                "2019-01-01T00:00:00 | C# exam (again) | at home" + Environment.NewLine +
                "2019-01-01T00:00:00 | C# exam (again) | at home" + Environment.NewLine +
                "2019-01-01T00:00:00 | Chalga party | Varna" + Environment.NewLine +
                "2001-01-01T10:30:02 | C# course" + Environment.NewLine +
                "2001-01-01T10:30:02 | C# course" + Environment.NewLine +
                "2001-01-01T10:30:02 | C# course - 138323 | Telerik academy" + Environment.NewLine +
                "2001-01-01T10:30:02 | C# course - 138323 | Telerik academy" + Environment.NewLine +
                "2001-01-01T10:30:02 | Exam - 692 | at school" + Environment.NewLine +
                "2001-01-01T10:30:02 | Exam - 692 | at school" + Environment.NewLine +
                "2001-01-01T10:30:03 | Chalga party" + Environment.NewLine +
                "2001-01-01T10:30:03 | Chalga party" + Environment.NewLine +
                "2001-01-01T10:30:01 | EXAM - 197258" + Environment.NewLine +
                "2001-01-01T10:30:01 | EXAM - 197258" + Environment.NewLine +
                "2001-01-01T10:30:01 | party | Home" + Environment.NewLine +
                "2001-01-01T10:30:01 | party Kiro | Home" + Environment.NewLine +
                "2001-01-01T10:30:03 | Chalga party" + Environment.NewLine +
                "2001-01-01T10:30:03 | Chalga party" + Environment.NewLine +
                "2001-01-01T10:30:03 | Chalga party - 974464 | at school - 479574" + Environment.NewLine +
                "2001-01-01T10:30:03 | Chalga party - 974464 | at school - 479574" + Environment.NewLine +
                "2001-01-01T10:30:03 | exam | at school" + Environment.NewLine +
                "2001-01-01T10:30:03 | exam | at school" + Environment.NewLine +
                "2001-01-01T10:30:03 | party Kiro" + Environment.NewLine +
                "2001-01-01T10:30:03 | party Kiro" + Environment.NewLine +
                "2001-01-01T10:30:03 | party Lora - 158117 | Kaspichan" + Environment.NewLine +
                "2001-01-01T10:30:03 | party Lora - 158117 | Kaspichan" + Environment.NewLine +
                "2001-01-01T10:30:03 | party Lora - 198672 | - 235165" + Environment.NewLine +
                "2001-01-01T10:30:03 | party Lora - 198672 | - 235165" + Environment.NewLine +
                "2001-01-01T11:00:00 | C# course | sofia" + Environment.NewLine +
                "2001-01-01T11:00:00 | C# course | sofia" + Environment.NewLine +
                "2001-01-01T11:00:00 | Chalga party - 679007" + Environment.NewLine +
                "2001-01-01T11:00:00 | Chalga party - 679007" + Environment.NewLine +
                "2012-03-31T23:59:59 | C# exam (again)" + Environment.NewLine +
                "2012-03-31T23:59:59 | C# exam (again)" + Environment.NewLine +
                "2012-03-31T23:59:59 | C# exam (again) - 979458 | - 922870" + Environment.NewLine +
                "2012-03-31T23:59:59 | C# exam (again) - 979458 | - 922870" + Environment.NewLine +
                "2012-03-31T23:59:59 | exam" + Environment.NewLine +
                "2012-03-31T23:59:59 | exam" + Environment.NewLine +
                "2019-01-01T00:00:00 | C# course | - 531989" + Environment.NewLine +
                "2019-01-01T00:00:00 | C# course | - 531989" + Environment.NewLine +
                "2019-01-01T00:00:00 | C# exam (again) | at home" + Environment.NewLine +
                "2019-01-01T00:00:00 | C# exam (again) | at home" + Environment.NewLine +
                "Event added" + Environment.NewLine +
                "Event added" + Environment.NewLine +
                "Event added" + Environment.NewLine +
                "Event added" + Environment.NewLine +
                "Event added" + Environment.NewLine +
                "Event added" + Environment.NewLine +
                "Event added" + Environment.NewLine +
                "Event added" + Environment.NewLine +
                "Event added" + Environment.NewLine +
                "Event added" + Environment.NewLine +
                "Event added" + Environment.NewLine +
                "Event added" + Environment.NewLine +
                "Event added" + Environment.NewLine +
                "Event added" + Environment.NewLine +
                "Event added" + Environment.NewLine +
                "Event added" + Environment.NewLine +
                "Event added" + Environment.NewLine +
                "Event added" + Environment.NewLine +
                "Event added" + Environment.NewLine +
                "Event added" + Environment.NewLine +
                "Event added" + Environment.NewLine +
                "Event added" + Environment.NewLine +
                "Event added" + Environment.NewLine +
                "Event added" + Environment.NewLine +
                "Event added" + Environment.NewLine +
                "Event added" + Environment.NewLine +
                "Event added" + Environment.NewLine +
                "Event added" + Environment.NewLine +
                "Event added" + Environment.NewLine +
                "Event added" + Environment.NewLine +
                "Event added" + Environment.NewLine +
                "Event added" + Environment.NewLine +
                "Event added" + Environment.NewLine +
                "Event added" + Environment.NewLine +
                "Event added" + Environment.NewLine +
                "Event added" + Environment.NewLine +
                "Event added" + Environment.NewLine +
                "Event added" + Environment.NewLine +
                "Event added" + Environment.NewLine +
                "Event added" + Environment.NewLine +
                "Event added" + Environment.NewLine +
                "Event added" + Environment.NewLine +
                "Event added" + Environment.NewLine +
                "Event added" + Environment.NewLine +
                "Event added" + Environment.NewLine +
                "Event added" + Environment.NewLine +
                "Event added" + Environment.NewLine +
                "Event added" + Environment.NewLine +
                "Event added" + Environment.NewLine +
                "Event added" + Environment.NewLine +
                "Event added" + Environment.NewLine +
                "Event added" + Environment.NewLine +
                "Event added" + Environment.NewLine +
                "Event added" + Environment.NewLine +
                "Event added" + Environment.NewLine +
                "Event added" + Environment.NewLine +
                "Event added" + Environment.NewLine +
                "Event added" + Environment.NewLine +
                "Event added" + Environment.NewLine +
                "Event added" + Environment.NewLine +
                "Event added" + Environment.NewLine +
                "Event added" + Environment.NewLine +
                "Event added" + Environment.NewLine +
                "Event added" + Environment.NewLine +
                "Event added" + Environment.NewLine +
                "Event added" + Environment.NewLine +
                "Event added" + Environment.NewLine +
                "Event added" + Environment.NewLine +
                "Event added" + Environment.NewLine +
                "Event added" + Environment.NewLine +
                "Event added" + Environment.NewLine +
                "Event added" + Environment.NewLine +
                "Event added" + Environment.NewLine +
                "Event added" + Environment.NewLine +
                "Event added" + Environment.NewLine +
                "Event added" + Environment.NewLine +
                "Event added" + Environment.NewLine +
                "Event added" + Environment.NewLine +
                "Event added" + Environment.NewLine +
                "Event added" + Environment.NewLine +
                "Event added" + Environment.NewLine +
                "Event added" + Environment.NewLine +
                "Event added" + Environment.NewLine +
                "Event added" + Environment.NewLine +
                "Event added" + Environment.NewLine +
                "Event added" + Environment.NewLine +
                "Event added" + Environment.NewLine +
                "Event added" + Environment.NewLine +
                "Event added" + Environment.NewLine +
                "Event added" + Environment.NewLine +
                "Event added" + Environment.NewLine +
                "Event added" + Environment.NewLine +
                "Event added" + Environment.NewLine +
                "Event added" + Environment.NewLine +
                "Event added" + Environment.NewLine +
                "Event added" + Environment.NewLine +
                "Event added" + Environment.NewLine +
                "Event added" + Environment.NewLine +
                "Event added" + Environment.NewLine +
                "Event added" + Environment.NewLine +
                "2001-01-01T10:30:01 | EXAM - 197258" + Environment.NewLine +
                "2001-01-01T10:30:01 | EXAM - 197258" + Environment.NewLine +
                "2001-01-01T10:30:01 | EXAM - 197258" + Environment.NewLine +
                "2001-01-01T10:30:01 | party | Home" + Environment.NewLine +
                "2001-01-01T10:30:01 | party Kiro | Home" + Environment.NewLine +
                "2001-01-01T10:30:01 | party Kiro | Home" + Environment.NewLine +
                "2001-01-01T10:30:01 | party Kiro | Home" + Environment.NewLine +
                "2001-01-01T22:00:00 | C# course" + Environment.NewLine +
                "2001-01-01T22:00:00 | C# course" + Environment.NewLine +
                "2001-01-01T22:00:00 | C# course" + Environment.NewLine +
                "2001-01-01T11:00:00 | C# course | sofia" + Environment.NewLine +
                "2001-01-01T11:00:00 | C# course | sofia" + Environment.NewLine +
                "2001-01-01T11:00:00 | C# course | sofia" + Environment.NewLine +
                "2001-01-01T11:00:00 | Chalga party - 679007" + Environment.NewLine +
                "2001-01-01T11:00:00 | Chalga party - 679007" + Environment.NewLine +
                "2001-01-01T10:30:01 | EXAM - 197258" + Environment.NewLine +
                "2001-01-01T10:30:01 | EXAM - 197258" + Environment.NewLine +
                "2001-01-01T10:30:01 | EXAM - 197258" + Environment.NewLine +
                "2001-01-01T10:30:01 | party | Home" + Environment.NewLine +
                "2001-01-01T10:30:01 | party Kiro | Home" + Environment.NewLine +
                "2001-01-01T10:30:01 | party Kiro | Home" + Environment.NewLine +
                "2001-01-01T10:30:01 | party Kiro | Home" + Environment.NewLine +
                "2001-01-01T10:30:01 | party Lora | Kaspichan" + Environment.NewLine +
                "2001-01-01T10:30:01 | party Lora - 488100" + Environment.NewLine +
                "2001-01-01T10:30:01 | party Lora - 488100" + Environment.NewLine +
                "2001-01-01T10:30:01 | party Lora - 488100" + Environment.NewLine +
                "2001-01-01T10:30:02 | C# course" + Environment.NewLine +
                "2001-01-01T10:30:02 | C# course" + Environment.NewLine +
                "2001-01-01T10:30:02 | C# course" + Environment.NewLine +
                "2001-01-01T10:30:02 | C# course - 138323 | Telerik academy" + Environment.NewLine +
                "2001-01-01T10:30:02 | C# course - 138323 | Telerik academy" + Environment.NewLine +
                "2001-01-01T10:30:02 | C# course - 138323 | Telerik academy" + Environment.NewLine +
                "2001-01-01T10:30:02 | Exam - 692 | at school" + Environment.NewLine +
                "2001-01-01T10:30:02 | Exam - 692 | at school" + Environment.NewLine +
                "2001-01-01T00:00:00 | Exam | at school" + Environment.NewLine +
                "2001-01-01T00:00:00 | Exam | at school" + Environment.NewLine +
                "2001-01-01T00:00:00 | Exam | at school" + Environment.NewLine +
                "2001-01-01T00:00:00 | Exam | Home" + Environment.NewLine +
                "2001-01-01T00:00:00 | Exam | Home" + Environment.NewLine +
                "2001-01-01T00:00:00 | Exam | Home" + Environment.NewLine +
                "2001-01-01T00:00:00 | PARTY - 352449 | - 408337" + Environment.NewLine +
                "2001-01-01T00:00:00 | PARTY - 352449 | - 408337" + Environment.NewLine +
                "2001-01-01T00:00:00 | PARTY - 352449 | - 408337" + Environment.NewLine +
                "2001-01-01T00:00:00 | party - 461156 | Kaspichan" + Environment.NewLine +
                "2001-01-01T00:00:00 | party - 461156 | Kaspichan" + Environment.NewLine +
                "2001-01-01T00:00:00 | party - 461156 | Kaspichan" + Environment.NewLine +
                "2001-01-01T00:00:00 | Rock party | Telerik academy - 799630" + Environment.NewLine +
                "2001-01-01T10:00:00 | Chalga party | at home" + Environment.NewLine +
                "Event added" + Environment.NewLine +
                "Event added" + Environment.NewLine +
                "Event added" + Environment.NewLine +
                "Event added" + Environment.NewLine +
                "Event added" + Environment.NewLine +
                "Event added" + Environment.NewLine +
                "Event added" + Environment.NewLine +
                "Event added" + Environment.NewLine +
                "Event added" + Environment.NewLine +
                "Event added" + Environment.NewLine +
                "Event added" + Environment.NewLine +
                "Event added" + Environment.NewLine +
                "Event added" + Environment.NewLine +
                "Event added" + Environment.NewLine +
                "Event added" + Environment.NewLine +
                "Event added" + Environment.NewLine +
                "Event added" + Environment.NewLine +
                "Event added" + Environment.NewLine +
                "Event added" + Environment.NewLine +
                "Event added" + Environment.NewLine +
                "Event added" + Environment.NewLine +
                "Event added" + Environment.NewLine +
                "Event added" + Environment.NewLine +
                "Event added" + Environment.NewLine +
                "Event added" + Environment.NewLine +
                "Event added" + Environment.NewLine +
                "Event added" + Environment.NewLine +
                "Event added" + Environment.NewLine +
                "Event added" + Environment.NewLine +
                "Event added" + Environment.NewLine +
                "Event added" + Environment.NewLine +
                "Event added" + Environment.NewLine +
                "Event added" + Environment.NewLine +
                "Event added" + Environment.NewLine +
                "Event added" + Environment.NewLine +
                "Event added" + Environment.NewLine +
                "Event added" + Environment.NewLine +
                "Event added" + Environment.NewLine +
                "Event added" + Environment.NewLine +
                "Event added" + Environment.NewLine +
                "Event added" + Environment.NewLine +
                "Event added" + Environment.NewLine +
                "Event added" + Environment.NewLine +
                "Event added" + Environment.NewLine +
                "Event added" + Environment.NewLine +
                "Event added" + Environment.NewLine +
                "Event added" + Environment.NewLine +
                "Event added" + Environment.NewLine +
                "Event added" + Environment.NewLine +
                "Event added" + Environment.NewLine +
                "Event added" + Environment.NewLine +
                "Event added" + Environment.NewLine +
                "Event added" + Environment.NewLine +
                "Event added" + Environment.NewLine +
                "Event added" + Environment.NewLine +
                "Event added" + Environment.NewLine +
                "Event added" + Environment.NewLine +
                "Event added" + Environment.NewLine +
                "Event added" + Environment.NewLine +
                "Event added" + Environment.NewLine +
                "Event added" + Environment.NewLine +
                "Event added" + Environment.NewLine +
                "Event added" + Environment.NewLine +
                "Event added" + Environment.NewLine +
                "Event added" + Environment.NewLine +
                "Event added" + Environment.NewLine +
                "Event added" + Environment.NewLine +
                "Event added" + Environment.NewLine +
                "Event added" + Environment.NewLine +
                "Event added" + Environment.NewLine +
                "Event added" + Environment.NewLine +
                "Event added" + Environment.NewLine +
                "Event added" + Environment.NewLine +
                "Event added" + Environment.NewLine +
                "Event added" + Environment.NewLine +
                "Event added" + Environment.NewLine +
                "Event added" + Environment.NewLine +
                "Event added" + Environment.NewLine +
                "Event added" + Environment.NewLine +
                "Event added" + Environment.NewLine +
                "Event added" + Environment.NewLine +
                "Event added" + Environment.NewLine +
                "Event added" + Environment.NewLine +
                "Event added" + Environment.NewLine +
                "Event added" + Environment.NewLine +
                "Event added" + Environment.NewLine +
                "Event added" + Environment.NewLine +
                "Event added" + Environment.NewLine +
                "Event added" + Environment.NewLine +
                "Event added" + Environment.NewLine +
                "Event added" + Environment.NewLine +
                "Event added" + Environment.NewLine +
                "Event added" + Environment.NewLine +
                "Event added" + Environment.NewLine +
                "Event added" + Environment.NewLine +
                "Event added" + Environment.NewLine +
                "Event added" + Environment.NewLine +
                "Event added" + Environment.NewLine +
                "Event added" + Environment.NewLine +
                "Event added" + Environment.NewLine +
                "2001-01-01T10:30:01 | EXAM - 197258" + Environment.NewLine +
                "2001-01-01T10:30:01 | EXAM - 197258" + Environment.NewLine +
                "2001-01-01T10:30:01 | EXAM - 197258" + Environment.NewLine +
                "2001-01-01T10:30:01 | EXAM - 197258" + Environment.NewLine +
                "2001-01-01T10:30:01 | party | Home" + Environment.NewLine +
                "2001-01-01T10:30:01 | party Kiro | Home" + Environment.NewLine +
                "2001-01-01T10:30:01 | party Kiro | Home" + Environment.NewLine +
                "2001-01-01T22:00:00 | C# course" + Environment.NewLine +
                "2001-01-01T22:00:00 | C# course" + Environment.NewLine +
                "2001-01-01T22:00:00 | C# course" + Environment.NewLine +
                "2001-01-01T11:00:00 | C# course | sofia" + Environment.NewLine +
                "2001-01-01T11:00:00 | C# course | sofia" + Environment.NewLine +
                "2001-01-01T11:00:00 | C# course | sofia" + Environment.NewLine +
                "2001-01-01T11:00:00 | C# course | sofia" + Environment.NewLine +
                "2001-01-01T11:00:00 | Chalga party - 679007" + Environment.NewLine +
                "2001-01-01T10:30:01 | EXAM - 197258" + Environment.NewLine +
                "2001-01-01T10:30:01 | EXAM - 197258" + Environment.NewLine +
                "2001-01-01T10:30:01 | EXAM - 197258" + Environment.NewLine +
                "2001-01-01T10:30:01 | EXAM - 197258" + Environment.NewLine +
                "2001-01-01T10:30:01 | party | Home" + Environment.NewLine +
                "2001-01-01T10:30:01 | party Kiro | Home" + Environment.NewLine +
                "2001-01-01T10:30:01 | party Kiro | Home" + Environment.NewLine +
                "2001-01-01T10:30:01 | party Kiro | Home" + Environment.NewLine +
                "2001-01-01T10:30:01 | party Kiro | Home" + Environment.NewLine +
                "2001-01-01T10:30:01 | party Lora | Kaspichan" + Environment.NewLine +
                "2001-01-01T10:30:01 | party Lora | Kaspichan" + Environment.NewLine +
                "2001-01-01T10:30:01 | party Lora - 488100" + Environment.NewLine +
                "2001-01-01T10:30:01 | party Lora - 488100" + Environment.NewLine +
                "2001-01-01T10:30:01 | party Lora - 488100" + Environment.NewLine +
                "2001-01-01T10:30:01 | party Lora - 488100" + Environment.NewLine +
                "2001-01-01T10:30:02 | C# course" + Environment.NewLine +
                "2001-01-01T10:30:02 | C# course" + Environment.NewLine +
                "2001-01-01T10:30:02 | C# course" + Environment.NewLine +
                "2001-01-01T10:30:02 | C# course" + Environment.NewLine +
                "2001-01-01T00:00:00 | Exam | at school" + Environment.NewLine +
                "2001-01-01T00:00:00 | Exam | at school" + Environment.NewLine +
                "2001-01-01T00:00:00 | Exam | at school" + Environment.NewLine +
                "2001-01-01T00:00:00 | Exam | at school" + Environment.NewLine +
                "2001-01-01T00:00:00 | Exam | Home" + Environment.NewLine +
                "2001-01-01T00:00:00 | Exam | Home" + Environment.NewLine +
                "2001-01-01T00:00:00 | Exam | Home" + Environment.NewLine +
                "2001-01-01T00:00:00 | Exam | Home" + Environment.NewLine +
                "2001-01-01T00:00:00 | PARTY - 352449 | - 408337" + Environment.NewLine +
                "2001-01-01T00:00:00 | PARTY - 352449 | - 408337" + Environment.NewLine +
                "2001-01-01T00:00:00 | PARTY - 352449 | - 408337" + Environment.NewLine +
                "2001-01-01T00:00:00 | PARTY - 352449 | - 408337" + Environment.NewLine +
                "2001-01-01T00:00:00 | party - 461156 | Kaspichan" + Environment.NewLine +
                "2001-01-01T00:00:00 | party - 461156 | Kaspichan" + Environment.NewLine +
                "27 events deleted" + Environment.NewLine +
                "No events found" + Environment.NewLine +
                "18 events deleted" + Environment.NewLine +
                "21 events deleted" + Environment.NewLine +
                "No events found" + Environment.NewLine +
                "2012-03-31T23:59:57 | EXAM - 194681 | at school" + Environment.NewLine +
                "2012-03-31T23:59:57 | EXAM - 194681 | at school" + Environment.NewLine +
                "2012-03-31T23:59:57 | EXAM - 194681 | at school" + Environment.NewLine +
                "2012-03-31T23:59:57 | EXAM - 194681 | at school" + Environment.NewLine +
                "2012-03-31T23:59:57 | Rock party - 407026 | home - 681328" + Environment.NewLine +
                "2012-03-31T23:59:57 | Rock party - 407026 | home - 681328" + Environment.NewLine +
                "2012-03-31T23:59:59 | C# exam (again)" + Environment.NewLine +
                "2012-03-31T23:59:59 | C# exam (again)" + Environment.NewLine +
                "2001-02-01T00:00:00 | Chalga party | Plovdiv" + Environment.NewLine +
                "2012-03-31T23:59:59 | C# exam (again)" + Environment.NewLine +
                "2001-01-01T10:30:03 | Chalga party" + Environment.NewLine +
                "2001-01-01T10:30:03 | Chalga party" + Environment.NewLine +
                "2001-01-01T10:30:03 | Chalga party" + Environment.NewLine +
                "2001-01-01T10:30:03 | Chalga party" + Environment.NewLine +
                "2001-01-01T10:30:03 | Chalga party - 974464 | at school - 479574" + Environment.NewLine +
                "2001-01-01T10:30:03 | Chalga party - 974464 | at school - 479574" + Environment.NewLine +
                "2001-01-01T10:30:03 | Chalga party - 974464 | at school - 479574" + Environment.NewLine +
                "2001-01-01T10:30:03 | Chalga party - 974464 | at school - 479574" + Environment.NewLine +
                "2001-01-01T10:30:03 | exam | at school" + Environment.NewLine +
                "2001-01-01T10:30:03 | exam | at school" + Environment.NewLine +
                "2001-01-01T10:30:03 | exam | at school" + Environment.NewLine +
                "2001-01-01T10:30:03 | exam | at school" + Environment.NewLine +
                "2001-01-01T10:30:03 | party Kiro" + Environment.NewLine +
                "Event added" + Environment.NewLine +
                "Event added" + Environment.NewLine +
                "Event added" + Environment.NewLine +
                "Event added" + Environment.NewLine +
                "Event added" + Environment.NewLine +
                "Event added" + Environment.NewLine +
                "Event added" + Environment.NewLine +
                "Event added" + Environment.NewLine +
                "Event added" + Environment.NewLine +
                "Event added" + Environment.NewLine +
                "2012-03-31T23:59:59 | C# exam (again)" + Environment.NewLine +
                "2012-03-31T23:59:59 | C# exam (again)" + Environment.NewLine +
                "2012-03-31T23:59:59 | C# exam (again)" + Environment.NewLine +
                "2012-03-31T23:59:59 | C# exam (again)" + Environment.NewLine +
                "2012-03-31T23:59:59 | C# exam (again) - 979458 | - 922870" + Environment.NewLine +
                "2012-03-31T23:59:59 | C# exam (again) - 979458 | - 922870" + Environment.NewLine +
                "2012-03-31T23:59:59 | C# exam (again) - 979458 | - 922870" + Environment.NewLine +
                "2012-03-31T23:59:59 | C# exam (again) - 979458 | - 922870" + Environment.NewLine +
                "2012-03-31T23:59:59 | exam" + Environment.NewLine +
                "2012-03-31T23:59:59 | exam" + Environment.NewLine +
                "2012-03-31T23:59:59 | exam" + Environment.NewLine +
                "2001-01-01T10:30:02 | C# course" + Environment.NewLine +
                "2001-01-01T10:30:02 | C# course" + Environment.NewLine +
                "2001-01-01T10:30:02 | C# course" + Environment.NewLine +
                "2001-01-01T10:30:02 | C# course" + Environment.NewLine +
                "2001-01-01T10:30:02 | C# course - 138323 | Telerik academy" + Environment.NewLine +
                "2001-01-01T10:30:02 | C# course - 138323 | Telerik academy" + Environment.NewLine +
                "2001-01-01T10:30:02 | C# course - 138323 | Telerik academy" + Environment.NewLine +
                "2001-01-01T10:30:02 | C# course - 138323 | Telerik academy" + Environment.NewLine +
                "2001-01-01T10:30:01 | EXAM - 197258" + Environment.NewLine +
                "2001-01-01T10:30:01 | EXAM - 197258" + Environment.NewLine +
                "2001-01-01T10:30:01 | EXAM - 197258" + Environment.NewLine +
                "2001-01-01T10:30:01 | EXAM - 197258" + Environment.NewLine +
                "2001-01-01T10:30:03 | Chalga party" + Environment.NewLine +
                "2001-01-01T10:30:03 | Chalga party" + Environment.NewLine +
                "2001-01-01T10:30:03 | Chalga party" + Environment.NewLine +
                "2001-01-01T10:30:03 | Chalga party" + Environment.NewLine +
                "2001-01-01T10:30:03 | Chalga party - 974464 | at school - 479574" + Environment.NewLine +
                "2001-01-01T10:30:03 | Chalga party - 974464 | at school - 479574" + Environment.NewLine +
                "2001-01-01T10:30:03 | Chalga party - 974464 | at school - 479574" + Environment.NewLine +
                "2001-01-01T10:30:03 | Chalga party - 974464 | at school - 479574" + Environment.NewLine +
                "2001-01-01T10:30:03 | exam | at school" + Environment.NewLine +
                "2001-01-01T10:30:03 | exam | at school" + Environment.NewLine +
                "2001-01-01T10:30:03 | exam | at school" + Environment.NewLine +
                "2001-01-01T10:30:03 | exam | at school" + Environment.NewLine +
                "2001-01-01T10:30:03 | party Kiro" + Environment.NewLine +
                "2001-01-01T10:30:03 | party Kiro" + Environment.NewLine +
                "2001-01-01T10:30:03 | party Kiro" + Environment.NewLine +
                "2001-01-01T10:30:03 | party Kiro" + Environment.NewLine +
                "2012-03-31T23:59:59 | C# exam (again)" + Environment.NewLine +
                "2012-03-31T23:59:59 | C# exam (again)" + Environment.NewLine +
                "2012-03-31T23:59:59 | C# exam (again)" + Environment.NewLine +
                "2012-03-31T23:59:59 | C# exam (again)" + Environment.NewLine +
                "2012-03-31T23:59:59 | C# exam (again) - 979458 | - 922870" + Environment.NewLine +
                "2012-03-31T23:59:59 | C# exam (again) - 979458 | - 922870" + Environment.NewLine +
                "2012-03-31T23:59:59 | C# exam (again) - 979458 | - 922870" + Environment.NewLine +
                "2012-03-31T23:59:59 | C# exam (again) - 979458 | - 922870" + Environment.NewLine +
                "2012-03-31T23:59:59 | exam" + Environment.NewLine +
                "2012-03-31T23:59:59 | exam" + Environment.NewLine +
                "2001-01-01T00:00:00 | Exam | at school" + Environment.NewLine +
                "2001-01-01T00:00:00 | Exam | at school" + Environment.NewLine +
                "2001-01-01T00:00:00 | Exam | at school" + Environment.NewLine +
                "2001-01-01T00:00:00 | Exam | at school" + Environment.NewLine +
                "2001-01-01T00:00:00 | Exam | Home" + Environment.NewLine +
                "2001-01-01T00:00:00 | Exam | Home" + Environment.NewLine +
                "2001-01-01T00:00:00 | Exam | Home" + Environment.NewLine +
                "2001-01-01T00:00:00 | Exam | Home" + Environment.NewLine +
                "2001-01-01T00:00:00 | PARTY - 352449 | - 408337" + Environment.NewLine +
                "2001-01-01T00:00:00 | PARTY - 352449 | - 408337" + Environment.NewLine +
                "2001-01-01T00:00:00 | PARTY - 352449 | - 408337" + Environment.NewLine +
                "2001-01-01T00:00:00 | PARTY - 352449 | - 408337" + Environment.NewLine +
                "2001-01-01T00:00:00 | party - 461156 | Kaspichan" + Environment.NewLine +
                "2001-01-01T00:00:00 | party - 461156 | Kaspichan" + Environment.NewLine +
                "2001-01-01T00:00:00 | party - 461156 | Kaspichan" + Environment.NewLine +
                "2019-01-01T00:00:00 | C# course | - 531989" + Environment.NewLine +
                "2001-02-01T00:00:00 | Chalga party | Plovdiv" + Environment.NewLine +
                "2001-02-01T00:00:00 | Chalga party | Plovdiv" + Environment.NewLine +
                "2001-02-01T00:00:00 | Exam | Plovdiv" + Environment.NewLine +
                "2001-02-01T00:00:00 | Exam | Plovdiv" + Environment.NewLine +
                "2001-02-01T00:00:00 | Exam | Plovdiv" + Environment.NewLine +
                "2001-02-01T00:00:00 | Exam | Plovdiv" + Environment.NewLine +
                "2001-02-01T00:00:00 | Party LORA - 85232" + Environment.NewLine +
                "2001-02-01T00:00:00 | Party LORA - 85232" + Environment.NewLine +
                "2001-02-01T00:00:00 | Party LORA - 85232" + Environment.NewLine +
                "2001-02-01T00:00:00 | Party LORA - 85232" + Environment.NewLine +
                "2012-03-31T23:59:57 | EXAM - 194681 | at school" + Environment.NewLine +
                "2012-03-31T23:59:57 | EXAM - 194681 | at school" + Environment.NewLine +
                "2012-03-31T23:59:57 | EXAM - 194681 | at school" + Environment.NewLine +
                "2012-03-31T23:59:57 | EXAM - 194681 | at school" + Environment.NewLine +
                "2012-03-31T23:59:57 | Rock party - 407026 | home - 681328" + Environment.NewLine +
                "2012-03-31T23:59:57 | Rock party - 407026 | home - 681328" + Environment.NewLine +
                "2012-03-31T23:59:57 | Rock party - 407026 | home - 681328" + Environment.NewLine +
                "2012-03-31T23:59:57 | Rock party - 407026 | home - 681328" + Environment.NewLine +
                "2001-01-01T10:30:02 | C# course" + Environment.NewLine +
                "2001-01-01T10:30:02 | C# course" + Environment.NewLine +
                "2001-01-01T10:30:02 | C# course" + Environment.NewLine +
                "2001-01-01T10:30:02 | C# course" + Environment.NewLine +
                "2001-01-01T10:30:02 | C# course - 138323 | Telerik academy" + Environment.NewLine +
                "2001-01-01T10:30:02 | C# course - 138323 | Telerik academy" + Environment.NewLine +
                "2019-01-01T00:00:00 | C# course | - 531989" + Environment.NewLine +
                "2019-01-01T00:00:00 | C# course | - 531989" + Environment.NewLine +
                "2019-01-01T00:00:00 | C# course | - 531989" + Environment.NewLine +
                "2019-01-01T00:00:00 | C# course | - 531989" + Environment.NewLine +
                "2019-01-01T00:00:00 | C# exam (again) | at home" + Environment.NewLine +
                "2019-01-01T00:00:00 | C# exam (again) | at home" + Environment.NewLine +
                "2019-01-01T00:00:00 | C# exam (again) | at home" + Environment.NewLine +
                "2019-01-01T00:00:00 | C# exam (again) | at home" + Environment.NewLine +
                "2019-01-01T00:00:00 | Chalga party | Varna" + Environment.NewLine +
                "2019-01-01T00:00:00 | Chalga party | Varna" + Environment.NewLine +
                "2019-01-01T00:00:00 | Chalga party | Varna" + Environment.NewLine
                        ;
                    using (input)
                    {
                        Console.SetIn(input);

                var output = new StringWriter();
                using (output)
                {
                    Console.SetOut(output);

                    CalendarSystemNS.CalendarSystem.Main();

                    string actual = output.ToString();
                    Assert.AreEqual(expected, actual);
                }
            }
        }

        [TestMethod]
        public void MainTest008()
        {
            String testInFile =  @"Tests\test.008.in.txt";
            String testOutfile = @"Tests\test.008.out.txt";

            StreamReader inputTestIn = new StreamReader(testInFile);
            String inputCommands = "";
            try
            {
                using (inputTestIn)
                {
                    inputCommands = inputTestIn.ReadToEnd();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("The file could not be read:");
                Console.WriteLine(e.Message);
            }

            StreamReader inputTestOut = new StreamReader(testOutfile);
            String expectedOutput = "";
            try
            {
                using (inputTestOut)
                {
                    expectedOutput = inputTestOut.ReadToEnd();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("The file could not be read:");
                Console.WriteLine(e.Message);
            }

            var input = new StringReader(inputCommands);
            using (input)
            {
                Console.SetIn(input);

                var output = new StringWriter();
                using (output)
                {
                    Console.SetOut(output);

                    CalendarSystemNS.CalendarSystem.Main();

                    string actual = output.ToString();
                    Assert.AreEqual(expectedOutput, actual);
                }
            }
        }

        [TestMethod]
        public void MainTest009()
        {
            String testInFile = @"Tests\test.009.in.txt";
            String testOutfile = @"Tests\test.009.out.txt";

            StreamReader inputTestIn = new StreamReader(testInFile);
            String inputCommands = "";
            try
            {
                using (inputTestIn)
                {
                    inputCommands = inputTestIn.ReadToEnd();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("The file could not be read:");
                Console.WriteLine(e.Message);
            }

            StreamReader inputTestOut = new StreamReader(testOutfile);
            String expectedOutput = "";
            try
            {
                using (inputTestOut)
                {
                    expectedOutput = inputTestOut.ReadToEnd();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("The file could not be read:");
                Console.WriteLine(e.Message);
            }

            var input = new StringReader(inputCommands);
            using (input)
            {
                Console.SetIn(input);

                var output = new StringWriter();
                using (output)
                {
                    Console.SetOut(output);

                    CalendarSystemNS.CalendarSystem.Main();

                    string actual = output.ToString();
                    Assert.AreEqual(expectedOutput, actual);
                }
            }
        }

        [TestMethod(), Timeout(60000)]
        public void MainTest010()
        {
            String testInFile = @"Tests\test.010.in.txt";
            String testOutfile = @"Tests\test.010.out.txt";

            StreamReader inputTestIn = new StreamReader(testInFile);
            String inputCommands = "";
            try
            {
                using (inputTestIn)
                {
                    inputCommands = inputTestIn.ReadToEnd();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("The file could not be read:");
                Console.WriteLine(e.Message);
            }

            StreamReader inputTestOut = new StreamReader(testOutfile);
            String expectedOutput = "";
            try
            {
                using (inputTestOut)
                {
                    expectedOutput = inputTestOut.ReadToEnd();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("The file could not be read:");
                Console.WriteLine(e.Message);
            }

            var input = new StringReader(inputCommands);
            using (input)
            {
                Console.SetIn(input);

                var output = new StringWriter();
                using (output)
                {
                    Console.SetOut(output);

                    CalendarSystemNS.CalendarSystem.Main();

                    string actual = output.ToString();
                    Assert.AreEqual(expectedOutput, actual);
                }
            }
        }

        [TestMethod(), Timeout(180000)]
        public void MainTest011()
        {
            String testInFile = @"Tests\test.011.in.txt";
            String testOutfile = @"Tests\test.011.out.txt";

            StreamReader inputTestIn = new StreamReader(testInFile);
            String inputCommands = "";
            try
            {
                using (inputTestIn)
                {
                    inputCommands = inputTestIn.ReadToEnd();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("The file could not be read:");
                Console.WriteLine(e.Message);
            }

            StreamReader inputTestOut = new StreamReader(testOutfile);
            String expectedOutput = "";
            try
            {
                using (inputTestOut)
                {
                    expectedOutput = inputTestOut.ReadToEnd();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("The file could not be read:");
                Console.WriteLine(e.Message);
            }

            var input = new StringReader(inputCommands);
            using (input)
            {
                Console.SetIn(input);

                var output = new StringWriter();
                using (output)
                {
                    Console.SetOut(output);

                    CalendarSystemNS.CalendarSystem.Main();

                    string actual = output.ToString();
                    Assert.AreEqual(expectedOutput, actual);
                }
            }
        }

        [TestMethod(), Timeout(180000)]
        public void MainTest012()
        {
            String testInFile = @"Tests\test.012.in.txt";
            String testOutfile = @"Tests\test.012.out.txt";

            StreamReader inputTestIn = new StreamReader(testInFile);
            String inputCommands = "";
            try
            {
                using (inputTestIn)
                {
                    inputCommands = inputTestIn.ReadToEnd();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("The file could not be read:");
                Console.WriteLine(e.Message);
            }

            StreamReader inputTestOut = new StreamReader(testOutfile);
            String expectedOutput = "";
            try
            {
                using (inputTestOut)
                {
                    expectedOutput = inputTestOut.ReadToEnd();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("The file could not be read:");
                Console.WriteLine(e.Message);
            }

            var input = new StringReader(inputCommands);
            using (input)
            {
                Console.SetIn(input);

                var output = new StringWriter();
                using (output)
                {
                    Console.SetOut(output);

                    CalendarSystemNS.CalendarSystem.Main();

                    string actual = output.ToString();
                    Assert.AreEqual(expectedOutput, actual);
                }
            }
        }

        [TestMethod(), Timeout(180000)]
        public void MainTest013()
        {
            String testInFile = @"Tests\test.013.in.txt";
            String testOutfile = @"Tests\test.013.out.txt";

            StreamReader inputTestIn = new StreamReader(testInFile);
            String inputCommands = "";
            try
            {
                using (inputTestIn)
                {
                    inputCommands = inputTestIn.ReadToEnd();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("The file could not be read:");
                Console.WriteLine(e.Message);
            }

            StreamReader inputTestOut = new StreamReader(testOutfile);
            String expectedOutput = "";
            try
            {
                using (inputTestOut)
                {
                    expectedOutput = inputTestOut.ReadToEnd();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("The file could not be read:");
                Console.WriteLine(e.Message);
            }

            var input = new StringReader(inputCommands);
            using (input)
            {
                Console.SetIn(input);

                var output = new StringWriter();
                using (output)
                {
                    Console.SetOut(output);

                    CalendarSystemNS.CalendarSystem.Main();

                    string actual = output.ToString();
                    Assert.AreEqual(expectedOutput, actual);
                }
            }
        }

        [TestMethod(), Timeout(180000)]
        public void MainTest014()
        {
            String testInFile = @"Tests\test.014.in.txt";
            String testOutfile = @"Tests\test.014.out.txt";

            StreamReader inputTestIn = new StreamReader(testInFile);
            String inputCommands = "";
            try
            {
                using (inputTestIn)
                {
                    inputCommands = inputTestIn.ReadToEnd();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("The file could not be read:");
                Console.WriteLine(e.Message);
            }

            StreamReader inputTestOut = new StreamReader(testOutfile);
            String expectedOutput = "";
            try
            {
                using (inputTestOut)
                {
                    expectedOutput = inputTestOut.ReadToEnd();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("The file could not be read:");
                Console.WriteLine(e.Message);
            }

            var input = new StringReader(inputCommands);
            using (input)
            {
                Console.SetIn(input);

                var output = new StringWriter();
                using (output)
                {
                    Console.SetOut(output);

                    CalendarSystemNS.CalendarSystem.Main();

                    string actual = output.ToString();
                    Assert.AreEqual(expectedOutput, actual);
                }
            }
        }

        [TestMethod(), Timeout(180000)]
        public void MainTest015()
        {
            String testInFile = @"Tests\test.015.in.txt";
            String testOutfile = @"Tests\test.015.out.txt";

            StreamReader inputTestIn = new StreamReader(testInFile);
            String inputCommands = "";
            try
            {
                using (inputTestIn)
                {
                    inputCommands = inputTestIn.ReadToEnd();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("The file could not be read:");
                Console.WriteLine(e.Message);
            }

            StreamReader inputTestOut = new StreamReader(testOutfile);
            String expectedOutput = "";
            try
            {
                using (inputTestOut)
                {
                    expectedOutput = inputTestOut.ReadToEnd();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("The file could not be read:");
                Console.WriteLine(e.Message);
            }

            var input = new StringReader(inputCommands);
            using (input)
            {
                Console.SetIn(input);

                var output = new StringWriter();
                using (output)
                {
                    Console.SetOut(output);

                    CalendarSystemNS.CalendarSystem.Main();

                    string actual = output.ToString();
                    Assert.AreEqual(expectedOutput, actual);
                }
            }
        }

        [TestMethod(), Timeout(240000)]
        public void MainTest016()
        {
            String testInFile = @"Tests\test.016.in.txt";
            String testOutfile = @"Tests\test.016.out.txt";

            StreamReader inputTestIn = new StreamReader(testInFile);
            String inputCommands = "";
            try
            {
                using (inputTestIn)
                {
                    inputCommands = inputTestIn.ReadToEnd();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("The file could not be read:");
                Console.WriteLine(e.Message);
            }

            StreamReader inputTestOut = new StreamReader(testOutfile);
            String expectedOutput = "";
            try
            {
                using (inputTestOut)
                {
                    expectedOutput = inputTestOut.ReadToEnd();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("The file could not be read:");
                Console.WriteLine(e.Message);
            }

            var input = new StringReader(inputCommands);
            using (input)
            {
                Console.SetIn(input);

                var output = new StringWriter();
                using (output)
                {
                    Console.SetOut(output);

                    CalendarSystemNS.CalendarSystem.Main();

                    string actual = output.ToString();
                    Assert.AreEqual(expectedOutput, actual);
                }
            }
        }
    }
}
