﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Forms;
using System.Windows.Input;
using SmartHouse_Control.Session;
using CheckBox = System.Windows.Controls.CheckBox;
using ComboBox = System.Windows.Controls.ComboBox;
using KeyEventArgs = System.Windows.Input.KeyEventArgs;
using MessageBox = System.Windows.MessageBox;

namespace SmartHouse_Control.UI
{
    /// <summary>
    ///     Логика взаимодействия для qbe_menu.xaml
    /// </summary>
    public partial class qbe_menu : Window
    {
        #region Exit

        //Exit
        private void Window_Closing(object sender, CancelEventArgs e) {
            if (Owner is main_menu)
                (Owner as main_menu).is_active_menu = false;
            else
                (Owner as filter_menu).is_active_menu = false;
        }

        #endregion

        #region Fields 

        private readonly request r_qq = new request(); //Request generated
        private int number_condition; //Number of where conditions

        #endregion

        #region Start visual

        public qbe_menu() {
            InitializeComponent();
        }

        private void Info_OnAutoGeneratedColumns(object sender, EventArgs e) {
            for (var i = 0; i < info.Columns.Count; ++i)
                info.Columns[i].Width = new DataGridLength(1, DataGridLengthUnitType.Star);
        }

        #endregion

        #region SELECT QQ

        private void Doit_Click(object sender, RoutedEventArgs e) {
            var select = new List<object>();
            foreach (var item in data.Items)
                if ((item as CheckBox).IsChecked == true)
                    select.Add((item as CheckBox).Content);

            var from = new List<object>();
            foreach (var item in data_type.Items)
                if ((item as CheckBox).IsChecked == true)
                    from.Add((item as CheckBox).Content);

            List<object[]> where = null;
            if (select.Count == 0 || from.Count == 0) {
                MessageBox.Show(
                    "Ошибки в выборе сущностей и/или полей",
                    "Ошибка",
                    MessageBoxButton.OK,
                    MessageBoxImage.Error);
                return;
            }

            if (number_condition != 0) {
                where = new List<object[]>();
                if (!is_right_inp()) {
                    MessageBox.Show(
                        "Ошибки в заполнеии условий!",
                        "Ошибка",
                        MessageBoxButton.OK,
                        MessageBoxImage.Error);
                    return;
                }

                where = get_conditions();
            }

            info.ItemsSource = null;

            info.AutoGenerateColumns = true;


            var dt = r_qq.new_qq
            (
                select,
                from,
                where
            );

            if (dt == null)
                return;

            if (dt.Rows.Count == 0)
                MessageBox.Show(
                    "Не было найдено ни одной записи",
                    "Уведомление",
                    MessageBoxButton.OK,
                    MessageBoxImage.Information);
            info.ItemsSource = dt.DefaultView;


            info.CanUserAddRows = false;
            info.CanUserDeleteRows = false;
            info.CanUserReorderColumns = false;
            info.IsReadOnly = true;
            //dt.Dispose();
        }

        private List<object[]> get_conditions() {
            var arr = new List<object[]>();
            switch (number_condition) {
                case 1: {
                    add_first(ref arr);
                    break;
                }
                case 2: {
                    add_first(ref arr);
                    add_second(ref arr);
                    break;
                }
                case 3: {
                    add_first(ref arr);
                    add_second(ref arr);
                    add_three(ref arr);
                    break;
                }
                case 4: {
                    add_first(ref arr);
                    add_second(ref arr);
                    add_three(ref arr);
                    add_four(ref arr);
                    break;
                }
                case 5: {
                    add_first(ref arr);
                    add_second(ref arr);
                    add_three(ref arr);
                    add_four(ref arr);
                    add_five(ref arr);
                    break;
                }
            }

            return arr;
        }

        #region Get conditions

        /// <summary>
        ///     Add first
        /// </summary>
        /// <param name="arr"></param>
        private void add_first(ref List<object[]> arr) {
            var obj = new object[5];
            obj[0] = clause_one.Text;
            obj[1] = sign_one.Text;
            obj[2] = condition_one.Text;
            obj[3] = one_two.Text;
            obj[4] = condition_one.SelectedIndex == -1;

            arr.Add(obj);
        }

        /// <summary>
        ///     Add second
        /// </summary>
        /// <param name="arr"></param>
        private void add_second(ref List<object[]> arr) {
            var obj = new object[5];
            obj[0] = clause_two.Text;
            obj[1] = sign_two.Text;
            obj[2] = condition_two.Text;
            obj[3] = two_three.Text;
            obj[4] = condition_two.SelectedIndex == -1;

            arr.Add(obj);
        }

        /// <summary>
        ///     Add three
        /// </summary>
        /// <param name="arr"></param>
        private void add_three(ref List<object[]> arr) {
            var obj = new object[5];
            obj[0] = clause_three.Text;
            obj[1] = sign_three.Text;
            obj[2] = condition_three.Text;
            obj[3] = three_four.Text;
            obj[4] = condition_three.SelectedIndex == -1;

            arr.Add(obj);
        }

        /// <summary>
        ///     Add four
        /// </summary>
        /// <param name="arr"></param>
        private void add_four(ref List<object[]> arr) {
            var obj = new object[5];
            obj[0] = clause_four.Text;
            obj[1] = sign_four.Text;
            obj[2] = condition_four.Text;
            obj[3] = four_five.Text;
            obj[4] = condition_four.SelectedIndex == -1;

            arr.Add(obj);
        }

        /// <summary>
        ///     Add five
        /// </summary>
        /// <param name="arr"></param>
        private void add_five(ref List<object[]> arr) {
            var obj = new object[5];
            obj[0] = clause_five.Text;
            obj[1] = sign_five.Text;
            obj[2] = condition_five.Text;
            obj[3] = "";
            obj[4] = condition_five.SelectedIndex == -1;

            arr.Add(obj);
        }

        #endregion

        private bool is_right_inp() {
            switch (number_condition) {
                case 5:
                    return is_five_condition() &&
                           is_four_condition() &&
                           is_three_condition() &&
                           is_two_condition() &&
                           is_one_condition() &&
                           one_two.Text != "" &&
                           two_three.Text != "" &&
                           three_four.Text != "" &&
                           four_five.Text != "";
                case 4:
                    return is_four_condition() &&
                           is_three_condition() &&
                           is_two_condition() &&
                           is_one_condition() &&
                           one_two.Text != "" &&
                           two_three.Text != "" &&
                           three_four.Text != "";
                case 3:
                    return is_three_condition() &&
                           is_two_condition() &&
                           is_one_condition() &&
                           one_two.Text != "" &&
                           two_three.Text != "";
                case 2:
                    return is_two_condition() &&
                           is_one_condition() &&
                           one_two.Text != "";
                case 1:
                    return is_one_condition();
            }

            return false;
        }

        #region Right Conditions

        /// <summary>
        ///     Check 1 condition
        /// </summary>
        /// <returns></returns>
        private bool is_one_condition() {
            return clause_one.Text != "" &&
                   sign_one.Text != "" &&
                   condition_one.Text != "";
        }

        /// <summary>
        ///     Check 2 condition
        /// </summary>
        /// <returns></returns>
        private bool is_two_condition() {
            return clause_two.Text != "" &&
                   sign_two.Text != "" &&
                   condition_two.Text != "";
        }

        /// <summary>
        ///     Check 3 condition
        /// </summary>
        /// <returns></returns>
        private bool is_three_condition() {
            return clause_three.Text != "" &&
                   sign_three.Text != "" &&
                   condition_three.Text != "";
        }

        /// <summary>
        ///     Check 4 condition
        /// </summary>
        /// <returns></returns>
        private bool is_four_condition() {
            return clause_four.Text != "" &&
                   sign_four.Text != "" &&
                   condition_four.Text != "";
        }

        /// <summary>
        ///     Check 5 condition
        /// </summary>
        /// <returns></returns>
        private bool is_five_condition() {
            return clause_five.Text != "" &&
                   sign_five.Text != "" &&
                   condition_five.Text != "";
        }

        #endregion

        #endregion

        #region Conditions

        #region Add and remove

        private void Minus_condition_Click(object sender, RoutedEventArgs e) {
            if (number_condition == 0)
                return;

            switch (number_condition) {
                case 1:
                    clause_one.IsEnabled =
                        condition_one.IsEnabled =
                            sign_one.IsEnabled = false;
                    clause_one.SelectedIndex =
                        condition_one.SelectedIndex =
                            sign_one.SelectedIndex = -1;
                    break;
                case 2:
                    clause_two.IsEnabled =
                        condition_two.IsEnabled =
                            sign_two.IsEnabled =
                                one_two.IsEnabled = false;
                    clause_two.SelectedIndex =
                        condition_two.SelectedIndex =
                            sign_two.SelectedIndex =
                                one_two.SelectedIndex = -1;
                    break;
                case 3:
                    clause_three.IsEnabled =
                        condition_three.IsEnabled =
                            sign_three.IsEnabled =
                                two_three.IsEnabled = false;
                    clause_three.SelectedIndex =
                        condition_three.SelectedIndex =
                            sign_three.SelectedIndex =
                                two_three.SelectedIndex = -1;
                    break;
                case 4:
                    clause_four.IsEnabled =
                        condition_four.IsEnabled =
                            sign_four.IsEnabled =
                                three_four.IsEnabled = false;

                    clause_four.SelectedIndex =
                        condition_four.SelectedIndex =
                            sign_four.SelectedIndex =
                                three_four.SelectedIndex = -1;
                    break;
                case 5:
                    clause_five.IsEnabled =
                        condition_five.IsEnabled =
                            sign_five.IsEnabled =
                                four_five.IsEnabled = false;
                    clause_five.SelectedIndex =
                        condition_five.SelectedIndex =
                            sign_five.SelectedIndex =
                                four_five.SelectedIndex = -1;
                    break;
            }

            number_condition--;
        }

        private void Plus_condition_Click(object sender, RoutedEventArgs e) {
            if (number_condition == 5)
                return;

            number_condition++;

            switch (number_condition) {
                case 1:
                    clause_one.IsEnabled =
                        condition_one.IsEnabled =
                            sign_one.IsEnabled = true;
                    break;
                case 2:
                    clause_two.IsEnabled =
                        condition_two.IsEnabled =
                            sign_two.IsEnabled =
                                one_two.IsEnabled = true;
                    break;
                case 3:
                    clause_three.IsEnabled =
                        condition_three.IsEnabled =
                            sign_three.IsEnabled =
                                two_three.IsEnabled = true;
                    break;
                case 4:
                    clause_four.IsEnabled =
                        condition_four.IsEnabled =
                            sign_four.IsEnabled =
                                three_four.IsEnabled = true;
                    break;
                case 5:
                    clause_five.IsEnabled =
                        condition_five.IsEnabled =
                            sign_five.IsEnabled =
                                four_five.IsEnabled = true;
                    break;
            }
        }

        #endregion

        #region Chars for input to the condition place

        /// <summary>
        ///     Check number
        /// </summary>
        /// <param name="c">Char</param>
        /// <returns></returns>
        private bool is_number(Key key) {
            switch (key) {
                case Key.D0:
                case Key.D1:
                case Key.D2:
                case Key.D3:
                case Key.D4:
                case Key.D5:
                case Key.D6:
                case Key.D7:
                case Key.D8:
                case Key.D9:
                    return true;
            }

            return false;
        }

        /// <summary>
        ///     Delete or back bttn
        /// </summary>
        /// <param name="key">Key</param>
        /// <returns></returns>
        private bool is_delete_or_back(Key key) {
            return key == Key.Delete || key == Key.Back;
        }

        /// <summary>
        ///     Check char input
        /// </summary>
        /// <param name="c">Char</param>
        /// <returns></returns>
        private bool is_char(char c) {
            if (c >= 'а' && c <= 'я')
                return true;
            if (c >= 'А' && c <= 'Я')
                return true;
            if (InputLanguage.CurrentInputLanguage.LayoutName == "Русская")
                if (c == 219 || c == 190 || c == 186 || c == 222 || c == 188 || c == 221)
                    return true;

            return false;
        }

        /// <summary>
        ///     Check english char
        /// </summary>
        /// <param name="c">Char</param>
        /// <returns></returns>
        private bool is_en_char(char c) {
            if (c >= 'a' && c <= 'z')
                return true;
            if (c >= 'A' && c <= 'Z')
                return true;

            return false;
        }

        #endregion

        private void Preview(object sender, KeyEventArgs e) {
            var input = (char) KeyInterop.VirtualKeyFromKey(e.Key);
            switch ((sender as ComboBox)?.Name) {
                case "condition_one":
                case "condition_two":
                case "condition_three":
                case "condition_four":
                case "condition_five":
                    e.Handled = !(is_number(e.Key) || is_delete_or_back(e.Key) || is_char(input) || is_en_char(input));
                    break;
            }
        }

        #endregion

        #region Data manupulation

        #region Datas input

        private void Uncheck_Object(object sender, RoutedEventArgs e) {
            var str = (sender as CheckBox).Content as string;
            var arr_to_remove = new List<object>(); //List to remove

            ComboBox[] conditions =
                {
                    condition_one,
                    condition_two,
                    condition_three,
                    condition_four,
                    condition_five,
                    clause_one,
                    clause_two,
                    clause_three,
                    clause_four,
                    clause_five
                };


            foreach (var item in data.Items)
                if (((item as CheckBox).Content as string).Split('.')[0] == str)
                    arr_to_remove.Add(item);

            foreach (var condition in conditions) {
                var arr_to_remove_condition = new List<object>(); //List to remove cond

                foreach (var item in condition.Items)
                    if (((item as ComboBoxItem).Content as string).Split('.')[0] == str)
                        arr_to_remove_condition.Add(item);

                foreach (var item in arr_to_remove_condition) condition.Items.Remove(item);
            }

            foreach (var item in arr_to_remove) data.Items.Remove(item);
        }

        private void Check_New_Object(object sender, RoutedEventArgs e) {
            CheckBox[] arr = null;
            ComboBox[] conditions =
                {
                    condition_one,
                    condition_two,
                    condition_three,
                    condition_four,
                    condition_five,
                    clause_one,
                    clause_two,
                    clause_three,
                    clause_four,
                    clause_five
                };


            switch (data_type.Items.IndexOf(sender as CheckBox)) {
                case 0: {
                    arr = new[]
                        {
                            new CheckBox
                                {
                                    Content = "Thing_Type." + Thing_Type.ID
                                },
                            new CheckBox
                                {
                                    Content = "Thing_Type." + Thing_Type.Name
                                }
                        };
                    break;
                } //Thing type
                case 1: {
                    arr = new[]
                        {
                            new CheckBox
                                {
                                    Content = "Model." + Model.ID
                                },
                            new CheckBox
                                {
                                    Content = "Model." + Model.Color
                                },
                            new CheckBox
                                {
                                    Content = "Model." + Model.ID_TYPE
                                },
                            new CheckBox
                                {
                                    Content = "Model." + Model.Material
                                }
                        };
                    break;
                } //Model
                case 2: {
                    arr = new[]
                        {
                            new CheckBox
                                {
                                    Content = "Sensor_Type." + Sensor_Type.ID
                                },
                            new CheckBox
                                {
                                    Content = "Sensor_Type." + Sensor_Type.Name
                                }
                        };
                    break;
                } //Sensor type
                case 3: {
                    arr = new[]
                        {
                            new CheckBox
                                {
                                    Content = "Time_Series." + Time_Series.ID
                                },
                            new CheckBox
                                {
                                    Content = "Time_Series." + Time_Series.Date
                                },
                            new CheckBox
                                {
                                    Content = "Time_Series." + Time_Series.ID_Option
                                },
                            new CheckBox
                                {
                                    Content = "Time_Series." + Time_Series.Time
                                },
                            new CheckBox
                                {
                                    Content = "Time_Series." + Time_Series.Time
                                },
                            new CheckBox
                                {
                                    Content = "Time_Series." + Time_Series.Value
                                }
                        };
                    break;
                } //Time series
                case 4: {
                    arr = new[]
                        {
                            new CheckBox
                                {
                                    Content = "Quantity." + Quantity.ID
                                },
                            new CheckBox
                                {
                                    Content = "Quantity." + Quantity.Name
                                },
                            new CheckBox
                                {
                                    Content = "Quantity." + Quantity.Max
                                },
                            new CheckBox
                                {
                                    Content = "Quantity." + Quantity.Min
                                },
                            new CheckBox
                                {
                                    Content = "Quantity." + Quantity.Postfix
                                }
                        };
                    break;
                } //Quantity
                case 5: {
                    arr = new[]
                        {
                            new CheckBox
                                {
                                    Content = "Option." + Option.ID
                                },
                            new CheckBox
                                {
                                    Content = "Option." + Option.Type_Option
                                },
                            new CheckBox
                                {
                                    Content = "Option." + Option.ID_Quantity
                                },
                            new CheckBox
                                {
                                    Content = "Option." + Option.ID_Sensor
                                }
                        };
                    break;
                } //Option
                case 6: {
                    arr = new[]
                        {
                            new CheckBox
                                {
                                    Content = "Sensor." + Sensor.ID
                                },
                            new CheckBox
                                {
                                    Content = "Sensor." + Sensor.Name
                                },
                            new CheckBox
                                {
                                    Content = "Sensor." + Sensor._Group
                                },
                            new CheckBox
                                {
                                    Content = "Sensor." + Sensor.Status
                                },
                            new CheckBox
                                {
                                    Content = "Sensor." + Sensor.ID_TYPE
                                },
                            new CheckBox
                                {
                                    Content = "Sensor." + Sensor.ID_Thing
                                },
                            new CheckBox
                                {
                                    Content = "Sensor." + Sensor.ID_RoomModel
                                }
                        };
                    break;
                } //Sensor
                case 7: {
                    arr = new[]
                        {
                            new CheckBox
                                {
                                    Content = "Thing." + Thing.ID
                                },
                            new CheckBox
                                {
                                    Content = "Thing." + Thing.Name
                                },
                            new CheckBox
                                {
                                    Content = "Thing." + Thing.ID_Model
                                },
                            new CheckBox
                                {
                                    Content = "Thing." + Thing.ID_RoomModel
                                }
                        };

                    break;
                } //Thing
                case 8: {
                    arr = new[]
                        {
                            new CheckBox
                                {
                                    Content = "RoomModel." + RoomModel.ID
                                },
                            new CheckBox
                                {
                                    Content = "RoomModel." + RoomModel.ID_Room
                                },
                            new CheckBox
                                {
                                    Content = "RoomModel." + RoomModel.ID_Model
                                }
                        };
                    break;
                } //RoomMode
                case 9: {
                    arr = new[]
                        {
                            new CheckBox
                                {
                                    Content = "Access." + Access.ID
                                },
                            new CheckBox
                                {
                                    Content = "Access." + Access.Access_LVL
                                },
                            new CheckBox
                                {
                                    Content = "Access." + Access.ID_UserRoom
                                }
                        };
                    break;
                } //Access
                case 10: {
                    arr = new[]
                        {
                            new CheckBox
                                {
                                    Content = "Files." + Files.ID
                                },
                            new CheckBox
                                {
                                    Content = "Files." + Files.cfg
                                },
                            new CheckBox
                                {
                                    Content = "Files." + Files.fileData
                                },
                            new CheckBox
                                {
                                    Content = "Files." + Files.is_current
                                }
                        };
                    break;
                } //Files 
                case 11: {
                    arr = new[]
                        {
                            new CheckBox
                                {
                                    Content = "Room." + Room.ID
                                },
                            new CheckBox
                                {
                                    Content = "Room." + Room.Name
                                },
                            new CheckBox
                                {
                                    Content = "Room." + Room.Floor
                                },
                            new CheckBox
                                {
                                    Content = "Room." + Room.ID_Building
                                }
                        };
                    break;
                } //Room
                case 12: {
                    arr = new[]
                        {
                            new CheckBox
                                {
                                    Content = "UserRoom." + UserRoom.ID
                                },
                            new CheckBox
                                {
                                    Content = "UserRoom." + UserRoom.ID_Room
                                },
                            new CheckBox
                                {
                                    Content = "UserRoom." + UserRoom.ID_User
                                }
                        };
                    break;
                } //UserRoom
                case 13: {
                    arr = new[]
                        {
                            new CheckBox
                                {
                                    Content = "User." + User.ID
                                },
                            new CheckBox
                                {
                                    Content = "User." + User._Function
                                },
                            new CheckBox
                                {
                                    Content = "User." + User.Organisation
                                },
                            new CheckBox
                                {
                                    Content = "User." + User.Avatar
                                },
                            new CheckBox
                                {
                                    Content = "User." + User.Login
                                },
                            new CheckBox
                                {
                                    Content = "User." + User.Password_Encrypted
                                },
                            new CheckBox
                                {
                                    Content = "User." + User.ID_Person
                                }
                        };
                    break;
                } //USer
                case 14: {
                    arr = new[]
                        {
                            new CheckBox
                                {
                                    Content = "Person." + Person.ID
                                },
                            new CheckBox
                                {
                                    Content = "Person." + Person.Name
                                },
                            new CheckBox
                                {
                                    Content = "Person." + Person.Second_Name
                                },
                            new CheckBox
                                {
                                    Content = "Person." + Person.Last_Name
                                },
                            new CheckBox
                                {
                                    Content = "Person." + Person.Contact_Info
                                },
                            new CheckBox
                                {
                                    Content = "Person." + Person.Mail
                                },
                            new CheckBox
                                {
                                    Content = "Person." + Person.ID_Address
                                }
                        };
                    break;
                } //Person
                case 15: {
                    arr = new[]
                        {
                            new CheckBox
                                {
                                    Content = "Address." + Address.ID
                                },
                            new CheckBox
                                {
                                    Content = "Address." + Address.Name
                                }
                        };
                    break;
                } //Address
                case 16: {
                    arr = new[]
                        {
                            new CheckBox
                                {
                                    Content = "Building." + Building.ID
                                },
                            new CheckBox
                                {
                                    Content = "Building." + Building.Type
                                },
                            new CheckBox
                                {
                                    Content = "Building." + Building.Building_Year
                                },
                            new CheckBox
                                {
                                    Content = "Building." + Building.ID_Address
                                }
                        };
                    break;
                } //Building
            }

            foreach (var check_box in arr) {
                data.Items.Add(check_box);
                foreach (var item in conditions)
                    item.Items.Add(
                        new ComboBoxItem
                            {
                                Content = check_box.Content
                            }
                    );
            }
        }

        #endregion

        #region Enums

        private enum Thing_Type
        {
            ID,
            Name
        }

        private enum Model
        {
            ID,
            Color,
            Material,
            ID_TYPE
        }

        private enum Sensor_Type
        {
            ID,
            Name
        }

        private enum Time_Series
        {
            ID,
            Value,
            Time,
            Date,
            ID_Option
        }

        private enum Quantity
        {
            ID,
            Name,
            Postfix,
            Min,
            Max
        }

        private enum Option
        {
            ID,
            Type_Option,
            ID_Quantity,
            ID_Sensor
        }

        private enum Sensor
        {
            ID,
            Name,
            _Group,
            Status,
            ID_TYPE,
            ID_Thing,
            ID_RoomModel
        }

        private enum Thing
        {
            ID,
            Name,
            ID_Model,
            ID_RoomModel
        }

        private enum RoomModel
        {
            ID,
            ID_Room,
            ID_Model
        }

        private enum Access
        {
            ID,
            Access_LVL,
            ID_UserRoom
        }

        private enum UserRoom
        {
            ID,
            ID_User,
            ID_Room
        }

        private enum Room
        {
            ID,
            Name,
            Floor,
            ID_Building
        }

        private enum Files
        {
            fileData,
            cfg,
            is_current,
            ID
        }

        private enum User
        {
            ID,
            _Function,
            Organisation,
            Login,
            Password_Encrypted,
            Avatar,
            ID_Person
        }

        private enum Person
        {
            ID,
            Name,
            Second_Name,
            Last_Name,
            Contact_Info,
            Mail,
            ID_Address
        }

        private enum Building
        {
            ID,
            Type,
            Building_Year,
            ID_Address
        }

        private enum Address
        {
            ID,
            Name
        }

        #endregion

        #endregion
    }
}