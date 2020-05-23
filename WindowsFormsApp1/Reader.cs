using System;
using System.Collections.Generic;
using System.Text;
using VersOne.Epub;
using HtmlAgilityPack;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Text.RegularExpressions;
using System.IO;
namespace WindowsFormsApp1
{
    class Reader
    {
        public List<EpubNavigationItem> subChapters;
        public string title;
        public string author;
        public List<string> authors;
        public EpubBook epubBook;
        public SsadTest test = new SsadTest();
        public string chapterTitle;
        public string basePath = @"‪O:\Book";
        public Reader(string book_path)
        {
        
             epubBook = EpubReader.ReadBook(book_path);
             title = epubBook.Title;
             author = epubBook.Author;
             authors = epubBook.AuthorList;

            // Enumerating chaptersthis.SetUp();

            
            test.GoToYandex();

            for (var i = 0; i < epubBook.Navigation.Count - 1; i++)
            {
                chapterTitle = epubBook.Navigation[i].Title;
                PrintTextContentFile(epubBook.Navigation[i].HtmlContentFile);
            }
             
        }

        public  void PrintTextContentFile(EpubTextContentFile textContentFile)
        {
           
            HtmlDocument htmlDocument = new HtmlDocument();
            htmlDocument.LoadHtml(textContentFile.Content);
            StringBuilder sb = new StringBuilder();
            foreach (HtmlNode node in htmlDocument.DocumentNode.SelectNodes("//text()"))
            {
                sb.AppendLine(node.InnerText.Trim());
            }
            string contentText = sb.ToString();
            List<string> list = SplitTextForCharLengthForWord(contentText);
            foreach(string text in list)
            {
                
                h(text);
            }
        }

        public void h(string text)
        {

            Directory.CreateDirectory(basePath + @"\" + chapterTitle);      
            test.SetUp(basePath + @"\" + chapterTitle);
            test.Read(text);
        }

        static List<string> SplitTextForCharLengthForWord(string str)
        {
            List<string> list = new List<string>();
            string text = "";
            string[] words = Regex.Split(str, @"(?<=[ ])");

            for (var i = 0; i < words.Length -1 ; i++)
            {
                text += words[i];
                if(words.Length-1 != i && (text + words[i + 1]).Length > 1500)
                {
                    list.Add(text);
                    text = "";
                }
           }

            return list;
        }
    }
}
