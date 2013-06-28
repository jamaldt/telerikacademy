using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Text;



namespace Problem4___Free_Content.Test
{
    [TestClass]
    public class CommandTest
    {
        [TestMethod]
        public void UpdateCmdTestWithLongUrls()
        {
            string input = "Update: http://11.metallica.com/webhp?sourceid=chrome-instant&ix=ieb&ie=UTF-8&ion=1#sclient=psy-ab&hl=bg&site=webhp&q=%D0%B2%D1%81%D0%B8%D1%87%D0%BA%D0%B8%20%D1%81%D0%BC%D0%B5%20%D0%BE%D1%82%20%D0%9A%D0%B0%D1%81%D0%BF%D0%B8%D1%87%D0%B0%D0%BD%2C%20%D0%BC%D0%BE%D1%8F%20%D1%80%D0%BE%D0%B4%D0%B5%D0%BD%20%D0%B3%D1%80%D0%B0%D0%B4&oq=&aq=&aqi=&aql=&gs_l=&pbx=1&fp=45669e7a7f451412&ix=ieb&ion=1&bav=on.2,or.r_gc.r_pw.r_cp.,cf.osb&biw=1366&bih=673; http://11.metallica.com/webhp?sourceid=chrome-instant&ix=ieb&ie=UTF-8&ion=1#sclient=psy-ab&hl=bg&site=webhp&q=%D0%B2%D1%81%D0%B8%D1%87%D0%BA%D0%B8%20%D1%81%D0%BC%D0%B5%20%D0%BE%D1%82%20%D0%9A%D0%B0%D1%81%D0%BF%D0%B8%D1%87%D0%B0%D0%BD%2C%20%D0%BC%D0%BE%D1%8F%20%D1%80%D0%BE%D0%B4%D0%B5%D0%BD%20%D0%B3%D1%80%D0%B0%D0%B4&oq=&aq=&aqi=&aql=&gs_l=&pbx=1&fp=45669e7a7f451412&ix=ieb&ion=1&bav=on.2,or.r_gc.r_pw.r_cp.,cf.osb&biw=1366&bih=673NEW";
            Command cmd = new Command(input);
            string[] expected = new string[]
            {
                "http://11.metallica.com/webhp?sourceid=chrome-instant&ix=ieb&ie=UTF-8&ion=1#sclient=psy-ab&hl=bg&site=webhp&q=%D0%B2%D1%81%D0%B8%D1%87%D0%BA%D0%B8%20%D1%81%D0%BC%D0%B5%20%D0%BE%D1%82%20%D0%9A%D0%B0%D1%81%D0%BF%D0%B8%D1%87%D0%B0%D0%BD%2C%20%D0%BC%D0%BE%D1%8F%20%D1%80%D0%BE%D0%B4%D0%B5%D0%BD%20%D0%B3%D1%80%D0%B0%D0%B4&oq=&aq=&aqi=&aql=&gs_l=&pbx=1&fp=45669e7a7f451412&ix=ieb&ion=1&bav=on.2,or.r_gc.r_pw.r_cp.,cf.osb&biw=1366&bih=673",
                "http://11.metallica.com/webhp?sourceid=chrome-instant&ix=ieb&ie=UTF-8&ion=1#sclient=psy-ab&hl=bg&site=webhp&q=%D0%B2%D1%81%D0%B8%D1%87%D0%BA%D0%B8%20%D1%81%D0%BC%D0%B5%20%D0%BE%D1%82%20%D0%9A%D0%B0%D1%81%D0%BF%D0%B8%D1%87%D0%B0%D0%BD%2C%20%D0%BC%D0%BE%D1%8F%20%D1%80%D0%BE%D0%B4%D0%B5%D0%BD%20%D0%B3%D1%80%D0%B0%D0%B4&oq=&aq=&aqi=&aql=&gs_l=&pbx=1&fp=45669e7a7f451412&ix=ieb&ion=1&bav=on.2,or.r_gc.r_pw.r_cp.,cf.osb&biw=1366&bih=673NEW"

            };

            Assert.IsTrue(cmd.Arguments.Length == 2);
            Assert.AreEqual<string>(cmd.Arguments[0], expected[0]);
            Assert.AreEqual<string>(cmd.Arguments[1], expected[1]);
            
            
        }

        [TestMethod]
        public void FindCmdTest()
        {
            string input1 = "Add application: Exam; baba mi - 227390; 1525200001; http://energy-torrent.com/details.php?id=26980 - 43365";
            string input2 = "Add application: Exam; baba mi; 399080001; http://www.flickr.com/photos/telerik-academy/sets/72157629582907243/ - 117394";
            string inputFindExam = "Find: Exam; 10";

            Command cmd1 = new Command(input1);
            Command cmd2 = new Command(input2);
            Command cmdFind = new Command(inputFindExam);

            StringBuilder sb = new StringBuilder();
            SiteControler controler = new SiteControler(sb);
            controler.Execute(cmd1);
            controler.Execute(cmd2);
            controler.Execute(cmdFind);

            string actual = sb.ToString();

            string[] expected = new string[]
            {
                "http://11.metallica.com/webhp?sourceid=chrome-instant&ix=ieb&ie=UTF-8&ion=1#sclient=psy-ab&hl=bg&site=webhp&q=%D0%B2%D1%81%D0%B8%D1%87%D0%BA%D0%B8%20%D1%81%D0%BC%D0%B5%20%D0%BE%D1%82%20%D0%9A%D0%B0%D1%81%D0%BF%D0%B8%D1%87%D0%B0%D0%BD%2C%20%D0%BC%D0%BE%D1%8F%20%D1%80%D0%BE%D0%B4%D0%B5%D0%BD%20%D0%B3%D1%80%D0%B0%D0%B4&oq=&aq=&aqi=&aql=&gs_l=&pbx=1&fp=45669e7a7f451412&ix=ieb&ion=1&bav=on.2,or.r_gc.r_pw.r_cp.,cf.osb&biw=1366&bih=673",
                "http://11.metallica.com/webhp?sourceid=chrome-instant&ix=ieb&ie=UTF-8&ion=1#sclient=psy-ab&hl=bg&site=webhp&q=%D0%B2%D1%81%D0%B8%D1%87%D0%BA%D0%B8%20%D1%81%D0%BC%D0%B5%20%D0%BE%D1%82%20%D0%9A%D0%B0%D1%81%D0%BF%D0%B8%D1%87%D0%B0%D0%BD%2C%20%D0%BC%D0%BE%D1%8F%20%D1%80%D0%BE%D0%B4%D0%B5%D0%BD%20%D0%B3%D1%80%D0%B0%D0%B4&oq=&aq=&aqi=&aql=&gs_l=&pbx=1&fp=45669e7a7f451412&ix=ieb&ion=1&bav=on.2,or.r_gc.r_pw.r_cp.,cf.osb&biw=1366&bih=673NEW"

            };

            //Assert.IsTrue(cmd.Arguments.Length == 2);
            //Assert.AreEqual<string>(cmd.Arguments[0], expected[0]);
            //Assert.AreEqual<string>(cmd.Arguments[1], expected[1]);
            
            
        }
    }
}
