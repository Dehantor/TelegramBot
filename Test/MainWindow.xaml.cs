using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.IO;
using Microsoft.Win32;
using Telegram.Bot;
using Telegram.Bot.Args;
using System.Net;
using System.Net.Http;
using System.Diagnostics;

namespace Test
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        TelegramBotClient bot;
        public MainWindow()
        {
            InitializeComponent();
            //WebProxy proxy = new WebProxy(Address: new Uri("http://163.172.189.32:8811"));
            //HttpClientHandler httpClientHandler = new HttpClientHandler()
            //{
            //    Proxy = proxy
            //};

            //var hc = new HttpClient(handler: httpClientHandler, disposeHandler: true);
            bot = new TelegramBotClient("1250881160:AAH6QW-SFPpX6BFpa62IaY4c8p2ffuMFP9o");

            bot.OnMessage += Bot_onMessage;
            bot.StartReceiving();
        }

        private void  Bot_onMessage(object sender, MessageEventArgs e)
        {
            Debug.WriteLine("qwe");
            //textOutput.Text = "";
            //
            // textOutput.Text += e.Message.Text + "/rn";
            Dispatcher.Invoke(() =>
            {
                listMessage.Items.Add(new Msg() {
                    fistName = e.Message.Chat.FirstName,
                    id = e.Message.Chat.Id,
                    msg = e.Message.Text
                });
            });
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var user = (Msg)listMessage.SelectedItem;
            bot.SendTextMessageAsync(user.id, myMsg.Text);
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            new Window1().Show();
        }
    }
}
