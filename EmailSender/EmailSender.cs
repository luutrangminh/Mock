﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace EmailProvider
{
    public class EmailSender
    {
        static bool mailSent = true;
        private static void SendCompletedCallback(object sender, AsyncCompletedEventArgs e)
        {
            // Get the unique identifier for this asynchronous operation.
            String token = (string)e.UserState;

            if (e.Cancelled)
            {
                mailSent = false;
                Console.WriteLine("[{0}] Send canceled.", token);
            }
            if (e.Error != null)
            {
                mailSent = false;
                Console.WriteLine("[{0}] {1}", token, e.Error.ToString());
            }
            else
            {
                Console.WriteLine("Message sent.");
            }
        }

        public static bool isEmail(string email)
        {
            System.Text.RegularExpressions.Regex regex = 
                new System.Text.RegularExpressions.Regex(@"\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*");
            return regex.IsMatch(email);
        }

        public static bool Send(string email, string subject, string messageObj)
        {
            SmtpClient smtp = new SmtpClient();
            try
            {
                smtp.Host = "smtp.gmail.com";
                smtp.Port = 587;
                smtp.EnableSsl = true;
                smtp.Credentials = new NetworkCredential("freepaysolution@gmail.com", "123456freepay");
                MailAddress from = new MailAddress("freepaysolution@gmail.com",
                "FreePay " + (char)0xD8 + " Solution", System.Text.Encoding.UTF8);
                // Set destinations for the e-mail message.
                MailAddress to = new MailAddress(email);
                // Specify the message content.
                MailMessage message = new MailMessage(from, to);
                messageObj = "Xin chào <br>" +
                    messageObj +
                "<br/>---<br/>" +
                "<span style='color: rgb(134, 134, 134); font-family: roboto, helvetica, arial, sans-serif; font-size: 11px;'>Bạn đã nhận được thư này vì Bạn đã nêu địa chỉ email này khi đăng ký với quản trị viên của<span class='inbox-inbox-inbox-inbox-inbox-Apple-converted-space'>&nbsp;</span></span><a href='#' style='font-family: roboto, helvetica, arial, sans-serif; font-size: 11px;'>FreePay Ø Solution</a><span style='color: rgb(134, 134, 134); font-family: roboto, helvetica, arial, sans-serif; font-size: 11px;'>. Nếu Bạn không có gửi yêu cầu đăng ký, thì Bạn cứ bỏ qua email này thôi. Để đăng nhập vào nền tảng, Bạn vui lòng điền tên đăng nhập và mật khẩu mà Bạn đã nêu khi đăng ký.</span>&nbsp;&nbsp;<br style='color: rgb(134, 134, 134); font-family: roboto, helvetica, arial, sans-serif; font-size: 11px;'><span style='color: rgb(134, 134, 134); font-family: roboto, helvetica, arial, sans-serif; font-size: 11px;'>Thông tin cá nhân của bạn được bảo vệ.<span class='inbox-inbox-inbox-inbox-inbox-Apple-converted-space'>&nbsp;</span></span><a href='https://link.binomo.com/wf/click?upn=GB2FXq8XrPI-2FK20DpvpPtbGQ1qOFL0HffZ-2FJLjmjDBtkTzt0SFRwV-2B9KNggKC6hV3MhNW1WbcahlUSKkilPVOyt8iS-2FN0gw0teEO2LtbL9keLO-2BxkvjWFOTVBCZs0hlBf2zAU4jr8RjOEumK1JHMxw-3D-3D_MxX0S3njLG4NDV-2Bo6inWmo1bJqWTv5OsacD-2Bz22-2BMFtgrVC5YnxAMPtaAPXLhv9TD-2BvR5peGRUm17LhODa0779HtLMCyWOu0weWAL-2FOFpd56z-2BupEjpOKUPvhKta61DbWi0ajYn-2FfwRrdLQTH-2BqdYAbYi3eyGyr0RBLGS9QSZTQq80oV3ZmkyUy2nCnJkuOMJ8Pd8dX3lQjbGjthIJmyxwjDiBCK4EgpFONcDrOlcUwDO3jCPXm6X2moLutY6MXJtMfd3rsMaZpEYlifDO5-2B8Q-3D-3D' target='_blank' style='font-family: roboto, helvetica, arial, sans-serif; font-size: 11px;'>Chính sách bảo mật</a>&nbsp;&nbsp;<div><br><div><div style='color: rgb(0, 0, 0); font-family: &quot;times new roman&quot;; font-size: medium; display: inline-block; border-left: 2px solid rgb(0, 249, 154); padding-left: 10px;'><p style='font-family: helvetica, arial, sans-serif; font-size: 13px; line-height: 12px; color: rgb(33, 33, 33); margin: 0px;'><span style='font-weight: bold; color: rgb(0, 249, 154);'>Nguyễn Thiện Thanh</span><span class='inbox-inbox-inbox-inbox-inbox-inbox-inbox-inbox-inbox-Apple-converted-space'>&nbsp;</span>/<span class='inbox-inbox-inbox-inbox-inbox-inbox-inbox-inbox-inbox-Apple-converted-space'>&nbsp;</span><span style='font-size: 11px;'>Web Developer</span></p><p style='font-family: helvetica, arial, sans-serif; font-size: 11px; line-height: 15px; margin-top: 10px;'><span style='color: rgb(0, 249, 154);'>email:<span class='inbox-inbox-inbox-inbox-inbox-inbox-inbox-inbox-inbox-Apple-converted-space'>&nbsp;</span></span><a href='mailto:nguyenthienthanh.218@gmail.com' style='color: rgb(71, 124, 204); text-decoration-line: none; display: inline;'>nguyenthienthanh.218@gmail.com</a><span class='inbox-inbox-inbox-inbox-inbox-inbox-inbox-inbox-inbox-Apple-converted-space'>&nbsp;</span><br><span style='color: rgb(0, 249, 154);'>phone:<span class='inbox-inbox-inbox-inbox-inbox-inbox-inbox-inbox-inbox-Apple-converted-space'>&nbsp;</span></span><span style='color: rgb(33, 33, 33);'>(+84) 0917943218</span><span class='inbox-inbox-inbox-inbox-inbox-inbox-inbox-inbox-inbox-Apple-converted-space'>&nbsp;</span><br><span style='color: rgb(0, 249, 154);'>address:<span class='inbox-inbox-inbox-inbox-inbox-inbox-inbox-inbox-inbox-Apple-converted-space'>&nbsp;</span></span><span style='color: rgb(33, 33, 33);'>75/57 Võ Duy Ninh, P.22, Q.Bình Thạnh, TP.Hồ Chí Minh</span><span class='inbox-inbox-inbox-inbox-inbox-inbox-inbox-inbox-inbox-Apple-converted-space'>&nbsp;</span><br><span style='color: rgb(33, 33, 33);'></span><span style='display: block;'></span><a href='https://inbox.google.com/u/1/' style='color: rgb(71, 124, 204); text-decoration-line: none;'></a></p><p style='font-size: 0px; line-height: 0; font-family: helvetica, arial, sans-serif;'><a href='https://htmlsig.com/t/000001CAVD4Y' style='text-decoration-line: none; display: inline;'><img width='16' height='16' alt='Twitter' style='margin-bottom: 2px; border: none; display: inline;' src='https://ci5.googleusercontent.com/proxy/sxWxFcwSFYCwSBXJs8lOX8VNFDtZTxfoSrZK6Ck1bk_YCNYQZ22zachFqFiuRzXaV9Zl6RsBa6VKgWzinESoMiQmRe99ag589yGl1xP8GA=s0-d-e1-ft#https://s3.amazonaws.com/htmlsig-assets/round/twitter.png'><span class='inbox-inbox-inbox-inbox-inbox-inbox-inbox-inbox-inbox-Apple-converted-space'>&nbsp;</span></a><span style='white-space: nowrap;'><img width='2' src='https://ci6.googleusercontent.com/proxy/wu_nasMQvgujkWqFw0VMsW-Du2jSo6681tevUA0WRlUscqtAYCqt46KjsfRnLT8nNNuyZ9gHcUSlvXRbY0U2Ki4BGp5uzmgE=s0-d-e1-ft#https://s3.amazonaws.com/htmlsig-assets/spacer.gif'><span class='inbox-inbox-inbox-inbox-inbox-inbox-inbox-inbox-inbox-Apple-converted-space'>&nbsp;</span></span><a href='https://htmlsig.com/t/000001CCAVZY' style='text-decoration-line: none; display: inline;'><img width='16' height='16' alt='Facebook' style='margin-bottom: 2px; border: none; display: inline;' src='https://ci4.googleusercontent.com/proxy/Gon_bzewzlQWgb66KwW4V3BXHTmgGAxFURAuDc37VenPY1rxG6V1Yo0EST0UM_EvV13z6RX0nGXpmdn1P2pUgKTtVm75yb0lmHoR_yhKCK0=s0-d-e1-ft#https://s3.amazonaws.com/htmlsig-assets/round/facebook.png'><span class='inbox-inbox-inbox-inbox-inbox-inbox-inbox-inbox-inbox-Apple-converted-space'>&nbsp;</span></a><span style='white-space: nowrap;'><img width='2' src='https://ci6.googleusercontent.com/proxy/wu_nasMQvgujkWqFw0VMsW-Du2jSo6681tevUA0WRlUscqtAYCqt46KjsfRnLT8nNNuyZ9gHcUSlvXRbY0U2Ki4BGp5uzmgE=s0-d-e1-ft#https://s3.amazonaws.com/htmlsig-assets/spacer.gif'><span class='inbox-inbox-inbox-inbox-inbox-inbox-inbox-inbox-inbox-Apple-converted-space'>&nbsp;</span></span><a href='https://htmlsig.com/t/000001C9RVQM' style='text-decoration-line: none; display: inline;'><img width='16' height='16' alt='LinkedIn' style='margin-bottom: 2px; border: none; display: inline;' src='https://ci3.googleusercontent.com/proxy/Hcx7bTwi0RU6Fhh69npZePQU5M7BEwyyb1LcNkj5sQ9CqOxiUMbTwPDEbgJl0MhDD8CYW5eLxqFu9gCr9c1nsHCDDsxuObR1PHPDb5-MVV8=s0-d-e1-ft#https://s3.amazonaws.com/htmlsig-assets/round/linkedin.png'><span class='inbox-inbox-inbox-inbox-inbox-inbox-inbox-inbox-inbox-Apple-converted-space'>&nbsp;</span></a><span style='white-space: nowrap;'><img width='2' src='https://ci6.googleusercontent.com/proxy/wu_nasMQvgujkWqFw0VMsW-Du2jSo6681tevUA0WRlUscqtAYCqt46KjsfRnLT8nNNuyZ9gHcUSlvXRbY0U2Ki4BGp5uzmgE=s0-d-e1-ft#https://s3.amazonaws.com/htmlsig-assets/spacer.gif'><span class='inbox-inbox-inbox-inbox-inbox-inbox-inbox-inbox-inbox-Apple-converted-space'>&nbsp;</span></span><a href='https://htmlsig.com/t/000001CBD2D6' style='text-decoration-line: none; display: inline;'><img width='16' height='16' alt='Instagram' style='margin-bottom: 2px; border: none; display: inline;' src='https://ci4.googleusercontent.com/proxy/44wYWzvN1ZcKdKV4N7VwTRXo4XI2cje1YTfnsgpFuXadOStH0Xqb_8VY2H30XpJjwZxzlwZriBG6R80imTTVXljWZg8QZqWaOQhJCPwM0v5E=s0-d-e1-ft#https://s3.amazonaws.com/htmlsig-assets/round/instagram.png'><span class='inbox-inbox-inbox-inbox-inbox-inbox-inbox-inbox-inbox-Apple-converted-space'>&nbsp;</span></a><span style='color: rgb(33, 33, 33); font-family: &quot;helvetica neue&quot;, helvetica, arial, sans-serif; font-size: 13px;'>&nbsp;</span><span style='white-space: nowrap;'><img width='2' src='https://ci6.googleusercontent.com/proxy/wu_nasMQvgujkWqFw0VMsW-Du2jSo6681tevUA0WRlUscqtAYCqt46KjsfRnLT8nNNuyZ9gHcUSlvXRbY0U2Ki4BGp5uzmgE=s0-d-e1-ft#https://s3.amazonaws.com/htmlsig-assets/spacer.gif'></span></p></div></div></div>";
                // Include some non-ASCII characters in body and subject.
                message.Body = messageObj;

                //message.Body += "<br/>---<br/>";
                //message.Body += "<span style='color: rgb(134, 134, 134); font-family: roboto, helvetica, arial, sans-serif; font-size: 11px;'>Bạn đã nhận được thư này vì Bạn đã nêu địa chỉ email này khi đăng ký với quản trị viên của<span class='inbox-inbox-inbox-inbox-inbox-Apple-converted-space'>&nbsp;</span></span><a href='#' style='font-family: roboto, helvetica, arial, sans-serif; font-size: 11px;'>FreePay Ø Solution</a><span style='color: rgb(134, 134, 134); font-family: roboto, helvetica, arial, sans-serif; font-size: 11px;'>. Nếu Bạn không có gửi yêu cầu đăng ký, thì Bạn cứ bỏ qua email này thôi. Để đăng nhập vào nền tảng, Bạn vui lòng điền tên đăng nhập và mật khẩu mà Bạn đã nêu khi đăng ký.</span>&nbsp;&nbsp;<br style='color: rgb(134, 134, 134); font-family: roboto, helvetica, arial, sans-serif; font-size: 11px;'><span style='color: rgb(134, 134, 134); font-family: roboto, helvetica, arial, sans-serif; font-size: 11px;'>Thông tin cá nhân của bạn được bảo vệ.<span class='inbox-inbox-inbox-inbox-inbox-Apple-converted-space'>&nbsp;</span></span><a href='https://link.binomo.com/wf/click?upn=GB2FXq8XrPI-2FK20DpvpPtbGQ1qOFL0HffZ-2FJLjmjDBtkTzt0SFRwV-2B9KNggKC6hV3MhNW1WbcahlUSKkilPVOyt8iS-2FN0gw0teEO2LtbL9keLO-2BxkvjWFOTVBCZs0hlBf2zAU4jr8RjOEumK1JHMxw-3D-3D_MxX0S3njLG4NDV-2Bo6inWmo1bJqWTv5OsacD-2Bz22-2BMFtgrVC5YnxAMPtaAPXLhv9TD-2BvR5peGRUm17LhODa0779HtLMCyWOu0weWAL-2FOFpd56z-2BupEjpOKUPvhKta61DbWi0ajYn-2FfwRrdLQTH-2BqdYAbYi3eyGyr0RBLGS9QSZTQq80oV3ZmkyUy2nCnJkuOMJ8Pd8dX3lQjbGjthIJmyxwjDiBCK4EgpFONcDrOlcUwDO3jCPXm6X2moLutY6MXJtMfd3rsMaZpEYlifDO5-2B8Q-3D-3D' target='_blank' style='font-family: roboto, helvetica, arial, sans-serif; font-size: 11px;'>Chính sách bảo mật</a>&nbsp;&nbsp;<div><br><div><div style='color: rgb(0, 0, 0); font-family: &quot;times new roman&quot;; font-size: medium; display: inline-block; border-left: 2px solid rgb(0, 249, 154); padding-left: 10px;'><p style='font-family: helvetica, arial, sans-serif; font-size: 13px; line-height: 12px; color: rgb(33, 33, 33); margin: 0px;'><span style='font-weight: bold; color: rgb(0, 249, 154);'>Nguyễn Thiện Thanh</span><span class='inbox-inbox-inbox-inbox-inbox-inbox-inbox-inbox-inbox-Apple-converted-space'>&nbsp;</span>/<span class='inbox-inbox-inbox-inbox-inbox-inbox-inbox-inbox-inbox-Apple-converted-space'>&nbsp;</span><span style='font-size: 11px;'>Web Developer</span></p><p style='font-family: helvetica, arial, sans-serif; font-size: 11px; line-height: 15px; margin-top: 10px;'><span style='color: rgb(0, 249, 154);'>email:<span class='inbox-inbox-inbox-inbox-inbox-inbox-inbox-inbox-inbox-Apple-converted-space'>&nbsp;</span></span><a href='mailto:nguyenthienthanh.218@gmail.com' style='color: rgb(71, 124, 204); text-decoration-line: none; display: inline;'>nguyenthienthanh.218@gmail.com</a><span class='inbox-inbox-inbox-inbox-inbox-inbox-inbox-inbox-inbox-Apple-converted-space'>&nbsp;</span><br><span style='color: rgb(0, 249, 154);'>phone:<span class='inbox-inbox-inbox-inbox-inbox-inbox-inbox-inbox-inbox-Apple-converted-space'>&nbsp;</span></span><span style='color: rgb(33, 33, 33);'>(+84) 0917943218</span><span class='inbox-inbox-inbox-inbox-inbox-inbox-inbox-inbox-inbox-Apple-converted-space'>&nbsp;</span><br><span style='color: rgb(0, 249, 154);'>address:<span class='inbox-inbox-inbox-inbox-inbox-inbox-inbox-inbox-inbox-Apple-converted-space'>&nbsp;</span></span><span style='color: rgb(33, 33, 33);'>75/57 Võ Duy Ninh, P.22, Q.Bình Thạnh, TP.Hồ Chí Minh</span><span class='inbox-inbox-inbox-inbox-inbox-inbox-inbox-inbox-inbox-Apple-converted-space'>&nbsp;</span><br><span style='color: rgb(33, 33, 33);'></span><span style='display: block;'></span><a href='https://inbox.google.com/u/1/' style='color: rgb(71, 124, 204); text-decoration-line: none;'></a></p><p style='font-size: 0px; line-height: 0; font-family: helvetica, arial, sans-serif;'><a href='https://htmlsig.com/t/000001CAVD4Y' style='text-decoration-line: none; display: inline;'><img width='16' height='16' alt='Twitter' style='margin-bottom: 2px; border: none; display: inline;' src='https://ci5.googleusercontent.com/proxy/sxWxFcwSFYCwSBXJs8lOX8VNFDtZTxfoSrZK6Ck1bk_YCNYQZ22zachFqFiuRzXaV9Zl6RsBa6VKgWzinESoMiQmRe99ag589yGl1xP8GA=s0-d-e1-ft#https://s3.amazonaws.com/htmlsig-assets/round/twitter.png'><span class='inbox-inbox-inbox-inbox-inbox-inbox-inbox-inbox-inbox-Apple-converted-space'>&nbsp;</span></a><span style='white-space: nowrap;'><img width='2' src='https://ci6.googleusercontent.com/proxy/wu_nasMQvgujkWqFw0VMsW-Du2jSo6681tevUA0WRlUscqtAYCqt46KjsfRnLT8nNNuyZ9gHcUSlvXRbY0U2Ki4BGp5uzmgE=s0-d-e1-ft#https://s3.amazonaws.com/htmlsig-assets/spacer.gif'><span class='inbox-inbox-inbox-inbox-inbox-inbox-inbox-inbox-inbox-Apple-converted-space'>&nbsp;</span></span><a href='https://htmlsig.com/t/000001CCAVZY' style='text-decoration-line: none; display: inline;'><img width='16' height='16' alt='Facebook' style='margin-bottom: 2px; border: none; display: inline;' src='https://ci4.googleusercontent.com/proxy/Gon_bzewzlQWgb66KwW4V3BXHTmgGAxFURAuDc37VenPY1rxG6V1Yo0EST0UM_EvV13z6RX0nGXpmdn1P2pUgKTtVm75yb0lmHoR_yhKCK0=s0-d-e1-ft#https://s3.amazonaws.com/htmlsig-assets/round/facebook.png'><span class='inbox-inbox-inbox-inbox-inbox-inbox-inbox-inbox-inbox-Apple-converted-space'>&nbsp;</span></a><span style='white-space: nowrap;'><img width='2' src='https://ci6.googleusercontent.com/proxy/wu_nasMQvgujkWqFw0VMsW-Du2jSo6681tevUA0WRlUscqtAYCqt46KjsfRnLT8nNNuyZ9gHcUSlvXRbY0U2Ki4BGp5uzmgE=s0-d-e1-ft#https://s3.amazonaws.com/htmlsig-assets/spacer.gif'><span class='inbox-inbox-inbox-inbox-inbox-inbox-inbox-inbox-inbox-Apple-converted-space'>&nbsp;</span></span><a href='https://htmlsig.com/t/000001C9RVQM' style='text-decoration-line: none; display: inline;'><img width='16' height='16' alt='LinkedIn' style='margin-bottom: 2px; border: none; display: inline;' src='https://ci3.googleusercontent.com/proxy/Hcx7bTwi0RU6Fhh69npZePQU5M7BEwyyb1LcNkj5sQ9CqOxiUMbTwPDEbgJl0MhDD8CYW5eLxqFu9gCr9c1nsHCDDsxuObR1PHPDb5-MVV8=s0-d-e1-ft#https://s3.amazonaws.com/htmlsig-assets/round/linkedin.png'><span class='inbox-inbox-inbox-inbox-inbox-inbox-inbox-inbox-inbox-Apple-converted-space'>&nbsp;</span></a><span style='white-space: nowrap;'><img width='2' src='https://ci6.googleusercontent.com/proxy/wu_nasMQvgujkWqFw0VMsW-Du2jSo6681tevUA0WRlUscqtAYCqt46KjsfRnLT8nNNuyZ9gHcUSlvXRbY0U2Ki4BGp5uzmgE=s0-d-e1-ft#https://s3.amazonaws.com/htmlsig-assets/spacer.gif'><span class='inbox-inbox-inbox-inbox-inbox-inbox-inbox-inbox-inbox-Apple-converted-space'>&nbsp;</span></span><a href='https://htmlsig.com/t/000001CBD2D6' style='text-decoration-line: none; display: inline;'><img width='16' height='16' alt='Instagram' style='margin-bottom: 2px; border: none; display: inline;' src='https://ci4.googleusercontent.com/proxy/44wYWzvN1ZcKdKV4N7VwTRXo4XI2cje1YTfnsgpFuXadOStH0Xqb_8VY2H30XpJjwZxzlwZriBG6R80imTTVXljWZg8QZqWaOQhJCPwM0v5E=s0-d-e1-ft#https://s3.amazonaws.com/htmlsig-assets/round/instagram.png'><span class='inbox-inbox-inbox-inbox-inbox-inbox-inbox-inbox-inbox-Apple-converted-space'>&nbsp;</span></a><span style='color: rgb(33, 33, 33); font-family: &quot;helvetica neue&quot;, helvetica, arial, sans-serif; font-size: 13px;'>&nbsp;</span><span style='white-space: nowrap;'><img width='2' src='https://ci6.googleusercontent.com/proxy/wu_nasMQvgujkWqFw0VMsW-Du2jSo6681tevUA0WRlUscqtAYCqt46KjsfRnLT8nNNuyZ9gHcUSlvXRbY0U2Ki4BGp5uzmgE=s0-d-e1-ft#https://s3.amazonaws.com/htmlsig-assets/spacer.gif'></span></p></div></div></div>";
                message.BodyEncoding = Encoding.UTF8;
                message.Subject = subject;
                message.SubjectEncoding = Encoding.UTF8;
                message.IsBodyHtml = true;
                // Set the method that is called back when the send operation ends.
                smtp.SendCompleted += new
                SendCompletedEventHandler(SendCompletedCallback);
                smtp.Send(message);
                // Clean up.
                message.Dispose();
                return mailSent;
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
                return false;
            }
        }
    }
}