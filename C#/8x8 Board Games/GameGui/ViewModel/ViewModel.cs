using GameEngine;
using GameGui.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace GameGui.ViewModel
{
    public class ViewModel : BindableBase
    {

        // BAD HACK TO REMOVE AND READ HOW TO DO IT THE RIGHT WAY!!!
        public void StartGame()
        {
            var board = new Chess().Board;
            foreach (var figure in board)
            {
                if (figure != null)
                {
                    UpdateFigureProperty(figure.X, figure.Y, figure.Draw);
                }
            }
        }

        public ViewModel()
        {
            AddCommand = new DelegateCommand(
                o =>
                {
                    Str1 = "Add Command Executed";
                    StartGame();
                }
                , o =>
                {
                    return true;
                });
            ClearCommand = new DelegateCommand(
             o =>
             {
                 Str1 = "Clear Command Executed";
                 Cell_0_0 = "\u2656";
             }
             , o =>
             {
                 return true;
             });
            MyCommand = new DelegateCommand(
               o =>
               {
                   Str1 = "My Command Executed";
               }
               , o =>
               {
                   return true;
               });
        }

        private string str1;
        public string Str1
        {
            get { return str1; }
            set { SetProperty(ref str1, value); }
        }


        public ICommand AddCommand
        {
            get;
            private set;
        }

        public ICommand ClearCommand
        {
            get;
            private set;
        }

        public ICommand MyCommand
        {
            get;
            private set;
        }

        public void UpdateFigureProperty(int x, int y, string figure)
        {
            switch (x)
            {
                case 0:
                    switch (y)
                    {
                        case 0:
                            Cell_0_0 = figure;
                            break;
                        case 1:
                            Cell_0_1 = figure;
                            break;
                        case 2:
                            Cell_0_2 = figure;
                            break;
                        case 3:
                            Cell_0_3 = figure;
                            break;
                        case 4:
                            Cell_0_4 = figure;
                            break;
                        case 5:
                            Cell_0_5 = figure;
                            break;
                        case 6:
                            Cell_0_6 = figure;
                            break;
                        case 7:
                            Cell_0_7 = figure;
                            break;
                    }
                    break;
                case 1:
                    switch (y)
                    {
                        case 0:
                            Cell_1_0 = figure;
                            break;
                        case 1:
                            Cell_1_1 = figure;
                            break;
                        case 2:
                            Cell_1_2 = figure;
                            break;
                        case 3:
                            Cell_1_3 = figure;
                            break;
                        case 4:
                            Cell_1_4 = figure;
                            break;
                        case 5:
                            Cell_1_5 = figure;
                            break;
                        case 6:
                            Cell_1_6 = figure;
                            break;
                        case 7:
                            Cell_1_7 = figure;
                            break;
                    }
                    break;
                case 2:
                    switch (y)
                    {
                        case 0:
                            Cell_2_0 = figure;
                            break;
                        case 1:
                            Cell_2_1 = figure;
                            break;
                        case 2:
                            Cell_2_2 = figure;
                            break;
                        case 3:
                            Cell_2_3 = figure;
                            break;
                        case 4:
                            Cell_2_4 = figure;
                            break;
                        case 5:
                            Cell_2_5 = figure;
                            break;
                        case 6:
                            Cell_2_6 = figure;
                            break;
                        case 7:
                            Cell_2_7 = figure;
                            break;
                    }
                    break;
                case 3:
                    switch (y)
                    {
                        case 0:
                            Cell_3_0 = figure;
                            break;
                        case 1:
                            Cell_3_1 = figure;
                            break;
                        case 2:
                            Cell_3_2 = figure;
                            break;
                        case 3:
                            Cell_3_3 = figure;
                            break;
                        case 4:
                            Cell_3_4 = figure;
                            break;
                        case 5:
                            Cell_3_5 = figure;
                            break;
                        case 6:
                            Cell_3_6 = figure;
                            break;
                        case 7:
                            Cell_3_7 = figure;
                            break;
                    }
                    break;
                case 4:
                    switch (y)
                    {
                        case 0:
                            Cell_4_0 = figure;
                            break;
                        case 1:
                            Cell_4_1 = figure;
                            break;
                        case 2:
                            Cell_4_2 = figure;
                            break;
                        case 3:
                            Cell_4_3 = figure;
                            break;
                        case 4:
                            Cell_4_4 = figure;
                            break;
                        case 5:
                            Cell_4_5 = figure;
                            break;
                        case 6:
                            Cell_4_6 = figure;
                            break;
                        case 7:
                            Cell_4_7 = figure;
                            break;
                    }
                    break;
                case 5:
                    switch (y)
                    {
                        case 0:
                            Cell_5_0 = figure;
                            break;
                        case 1:
                            Cell_5_1 = figure;
                            break;
                        case 2:
                            Cell_5_2 = figure;
                            break;
                        case 3:
                            Cell_5_3 = figure;
                            break;
                        case 4:
                            Cell_5_4 = figure;
                            break;
                        case 5:
                            Cell_5_5 = figure;
                            break;
                        case 6:
                            Cell_5_6 = figure;
                            break;
                        case 7:
                            Cell_5_7 = figure;
                            break;
                    }
                    break;
                case 6:
                    switch (y)
                    {
                        case 0:
                            Cell_6_0 = figure;
                            break;
                        case 1:
                            Cell_6_1 = figure;
                            break;
                        case 2:
                            Cell_6_2 = figure;
                            break;
                        case 3:
                            Cell_6_3 = figure;
                            break;
                        case 4:
                            Cell_6_4 = figure;
                            break;
                        case 5:
                            Cell_6_5 = figure;
                            break;
                        case 6:
                            Cell_6_6 = figure;
                            break;
                        case 7:
                            Cell_6_7 = figure;
                            break;
                    }
                    break;
                case 7:
                    switch (y)
                    {
                        case 0:
                            Cell_7_0 = figure;
                            break;
                        case 1:
                            Cell_7_1 = figure;
                            break;
                        case 2:
                            Cell_7_2 = figure;
                            break;
                        case 3:
                            Cell_7_3 = figure;
                            break;
                        case 4:
                            Cell_7_4 = figure;
                            break;
                        case 5:
                            Cell_7_5 = figure;
                            break;
                        case 6:
                            Cell_7_6 = figure;
                            break;
                        case 7:
                            Cell_7_7 = figure;
                            break;
                    }
                    break;
            }
        }

        #region Property Cell declarations
        private string cell_0_0;
        public string Cell_0_0 { get { return cell_0_0; } set { SetProperty(ref cell_0_0, value); } }
        private string cell_0_1;
        public string Cell_0_1 { get { return cell_0_1; } set { SetProperty(ref cell_0_1, value); } }
        private string cell_0_2;
        public string Cell_0_2 { get { return cell_0_2; } set { SetProperty(ref cell_0_2, value); } }
        private string cell_0_3;
        public string Cell_0_3 { get { return cell_0_3; } set { SetProperty(ref cell_0_3, value); } }
        private string cell_0_4;
        public string Cell_0_4 { get { return cell_0_4; } set { SetProperty(ref cell_0_4, value); } }
        private string cell_0_5;
        public string Cell_0_5 { get { return cell_0_5; } set { SetProperty(ref cell_0_5, value); } }
        private string cell_0_6;
        public string Cell_0_6 { get { return cell_0_6; } set { SetProperty(ref cell_0_6, value); } }
        private string cell_0_7;
        public string Cell_0_7 { get { return cell_0_7; } set { SetProperty(ref cell_0_7, value); } }
        private string cell_1_0;
        public string Cell_1_0 { get { return cell_1_0; } set { SetProperty(ref cell_1_0, value); } }
        private string cell_1_1;
        public string Cell_1_1 { get { return cell_1_1; } set { SetProperty(ref cell_1_1, value); } }
        private string cell_1_2;
        public string Cell_1_2 { get { return cell_1_2; } set { SetProperty(ref cell_1_2, value); } }
        private string cell_1_3;
        public string Cell_1_3 { get { return cell_1_3; } set { SetProperty(ref cell_1_3, value); } }
        private string cell_1_4;
        public string Cell_1_4 { get { return cell_1_4; } set { SetProperty(ref cell_1_4, value); } }
        private string cell_1_5;
        public string Cell_1_5 { get { return cell_1_5; } set { SetProperty(ref cell_1_5, value); } }
        private string cell_1_6;
        public string Cell_1_6 { get { return cell_1_6; } set { SetProperty(ref cell_1_6, value); } }
        private string cell_1_7;
        public string Cell_1_7 { get { return cell_1_7; } set { SetProperty(ref cell_1_7, value); } }
        private string cell_2_0;
        public string Cell_2_0 { get { return cell_2_0; } set { SetProperty(ref cell_2_0, value); } }
        private string cell_2_1;
        public string Cell_2_1 { get { return cell_2_1; } set { SetProperty(ref cell_2_1, value); } }
        private string cell_2_2;
        public string Cell_2_2 { get { return cell_2_2; } set { SetProperty(ref cell_2_2, value); } }
        private string cell_2_3;
        public string Cell_2_3 { get { return cell_2_3; } set { SetProperty(ref cell_2_3, value); } }
        private string cell_2_4;
        public string Cell_2_4 { get { return cell_2_4; } set { SetProperty(ref cell_2_4, value); } }
        private string cell_2_5;
        public string Cell_2_5 { get { return cell_2_5; } set { SetProperty(ref cell_2_5, value); } }
        private string cell_2_6;
        public string Cell_2_6 { get { return cell_2_6; } set { SetProperty(ref cell_2_6, value); } }
        private string cell_2_7;
        public string Cell_2_7 { get { return cell_2_7; } set { SetProperty(ref cell_2_7, value); } }
        private string cell_3_0;
        public string Cell_3_0 { get { return cell_3_0; } set { SetProperty(ref cell_3_0, value); } }
        private string cell_3_1;
        public string Cell_3_1 { get { return cell_3_1; } set { SetProperty(ref cell_3_1, value); } }
        private string cell_3_2;
        public string Cell_3_2 { get { return cell_3_2; } set { SetProperty(ref cell_3_2, value); } }
        private string cell_3_3;
        public string Cell_3_3 { get { return cell_3_3; } set { SetProperty(ref cell_3_3, value); } }
        private string cell_3_4;
        public string Cell_3_4 { get { return cell_3_4; } set { SetProperty(ref cell_3_4, value); } }
        private string cell_3_5;
        public string Cell_3_5 { get { return cell_3_5; } set { SetProperty(ref cell_3_5, value); } }
        private string cell_3_6;
        public string Cell_3_6 { get { return cell_3_6; } set { SetProperty(ref cell_3_6, value); } }
        private string cell_3_7;
        public string Cell_3_7 { get { return cell_3_7; } set { SetProperty(ref cell_3_7, value); } }
        private string cell_4_0;
        public string Cell_4_0 { get { return cell_4_0; } set { SetProperty(ref cell_4_0, value); } }
        private string cell_4_1;
        public string Cell_4_1 { get { return cell_4_1; } set { SetProperty(ref cell_4_1, value); } }
        private string cell_4_2;
        public string Cell_4_2 { get { return cell_4_2; } set { SetProperty(ref cell_4_2, value); } }
        private string cell_4_3;
        public string Cell_4_3 { get { return cell_4_3; } set { SetProperty(ref cell_4_3, value); } }
        private string cell_4_4;
        public string Cell_4_4 { get { return cell_4_4; } set { SetProperty(ref cell_4_4, value); } }
        private string cell_4_5;
        public string Cell_4_5 { get { return cell_4_5; } set { SetProperty(ref cell_4_5, value); } }
        private string cell_4_6;
        public string Cell_4_6 { get { return cell_4_6; } set { SetProperty(ref cell_4_6, value); } }
        private string cell_4_7;
        public string Cell_4_7 { get { return cell_4_7; } set { SetProperty(ref cell_4_7, value); } }
        private string cell_5_0;
        public string Cell_5_0 { get { return cell_5_0; } set { SetProperty(ref cell_5_0, value); } }
        private string cell_5_1;
        public string Cell_5_1 { get { return cell_5_1; } set { SetProperty(ref cell_5_1, value); } }
        private string cell_5_2;
        public string Cell_5_2 { get { return cell_5_2; } set { SetProperty(ref cell_5_2, value); } }
        private string cell_5_3;
        public string Cell_5_3 { get { return cell_5_3; } set { SetProperty(ref cell_5_3, value); } }
        private string cell_5_4;
        public string Cell_5_4 { get { return cell_5_4; } set { SetProperty(ref cell_5_4, value); } }
        private string cell_5_5;
        public string Cell_5_5 { get { return cell_5_5; } set { SetProperty(ref cell_5_5, value); } }
        private string cell_5_6;
        public string Cell_5_6 { get { return cell_5_6; } set { SetProperty(ref cell_5_6, value); } }
        private string cell_5_7;
        public string Cell_5_7 { get { return cell_5_7; } set { SetProperty(ref cell_5_7, value); } }
        private string cell_6_0;
        public string Cell_6_0 { get { return cell_6_0; } set { SetProperty(ref cell_6_0, value); } }
        private string cell_6_1;
        public string Cell_6_1 { get { return cell_6_1; } set { SetProperty(ref cell_6_1, value); } }
        private string cell_6_2;
        public string Cell_6_2 { get { return cell_6_2; } set { SetProperty(ref cell_6_2, value); } }
        private string cell_6_3;
        public string Cell_6_3 { get { return cell_6_3; } set { SetProperty(ref cell_6_3, value); } }
        private string cell_6_4;
        public string Cell_6_4 { get { return cell_6_4; } set { SetProperty(ref cell_6_4, value); } }
        private string cell_6_5;
        public string Cell_6_5 { get { return cell_6_5; } set { SetProperty(ref cell_6_5, value); } }
        private string cell_6_6;
        public string Cell_6_6 { get { return cell_6_6; } set { SetProperty(ref cell_6_6, value); } }
        private string cell_6_7;
        public string Cell_6_7 { get { return cell_6_7; } set { SetProperty(ref cell_6_7, value); } }
        private string cell_7_0;
        public string Cell_7_0 { get { return cell_7_0; } set { SetProperty(ref cell_7_0, value); } }
        private string cell_7_1;
        public string Cell_7_1 { get { return cell_7_1; } set { SetProperty(ref cell_7_1, value); } }
        private string cell_7_2;
        public string Cell_7_2 { get { return cell_7_2; } set { SetProperty(ref cell_7_2, value); } }
        private string cell_7_3;
        public string Cell_7_3 { get { return cell_7_3; } set { SetProperty(ref cell_7_3, value); } }
        private string cell_7_4;
        public string Cell_7_4 { get { return cell_7_4; } set { SetProperty(ref cell_7_4, value); } }
        private string cell_7_5;
        public string Cell_7_5 { get { return cell_7_5; } set { SetProperty(ref cell_7_5, value); } }
        private string cell_7_6;
        public string Cell_7_6 { get { return cell_7_6; } set { SetProperty(ref cell_7_6, value); } }
        private string cell_7_7;
        public string Cell_7_7 { get { return cell_7_7; } set { SetProperty(ref cell_7_7, value); } }

        #endregion




    }
}
