using System;
using System.Collections.Generic;
using System.Text;
using VersOne.Epub;
using HtmlAgilityPack;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Text.RegularExpressions;
using System.IO;
using System.Linq;
using System.Threading;
using FfmpegMaster;
using Windows.UI.Xaml.Input;
using Google.Apis.YouTube.v3.Data;

namespace BookReader
{
    class Reader
    {
        public List<EpubNavigationItem> subChapters;
        public string title;
        public string author;
        public List<string> authors;
        public EpubBook epubBook;
        public SsadTest test;
        public string chapterTitle;
        public string basePath;
        public string lastCFullPath;
        public string ffmpegConcatComand;
        public string lastChapterTextFile;
        public string BufferPath;
        public UploadVideo uploader = new UploadVideo();

        public Reader(string book_path, string downloadPath, string imgPath, string describe, string bookName, string mainTags, string secondTags, int cChapter)
        {
            basePath = downloadPath;
            test = new SsadTest();
            epubBook = EpubReader.ReadBook(book_path);
            title = epubBook.Title;
            author = epubBook.Author;
            authors = epubBook.AuthorList;

            // Enumerating chaptersthis.SetUp();
            int continueChapter = 0;
            if (cChapter != 0)
            {
                 continueChapter = cChapter - 1;
            }

            test.SetUp(basePath);
            for (var i = continueChapter; i < epubBook.Navigation.Count - 1; i++)
            {
               

                //Save data about chapter we working with         
                chapterTitle = epubBook.Navigation[i].Title;
                lastCFullPath = basePath + @"\" + chapterTitle + " №" + i;
              
                BufferPath = basePath + @"\Buffer";
                lastChapterTextFile = BufferPath + @"\text.txt";

                Directory.CreateDirectory(BufferPath);

                Directory.Delete(BufferPath,true);
                for (var j = 0; j < 60; j++)
                {
                    if (!(Directory.Exists(BufferPath))) { break; }
                    Thread.Sleep(1000);
                }

                Directory.CreateDirectory(BufferPath);

                Directory.CreateDirectory(lastCFullPath);
                int res = PrintTextContentFile(epubBook.Navigation[i].HtmlContentFile);
               
                if (res == 1) {
                    ffmpegConcatComand = @" -f concat -safe 0 -i " + lastChapterTextFile + @" -c copy " + BufferPath + @"\Result.ogg";
                    Ffmpeg.Run(ffmpegConcatComand);

                    for (var j = 0; j < 30; j++)
                    {
                        if (File.Exists(BufferPath + @"\Result.ogg")) { break; }
                        Thread.Sleep(1000);
                    }
                    Thread.Sleep(1000);

                    string oggToMp4 = @" -r 1 -loop 1 -i " + imgPath + @" -i " + BufferPath + @"\Result.ogg" + "  -acodec copy -r 1 -shortest -vf -scale=1920x1080 " + BufferPath + @"\Result.mp4";
                    Ffmpeg.Run(oggToMp4);

                    for (var j = 0; j < 60; j++)
                    {
                        if (File.Exists(BufferPath + @"\Result.mp4")) { break; }
                        Thread.Sleep(60000);
                    }
                    
                    Thread.Sleep(1000);

                    File.Move(BufferPath + @"\Result.ogg", lastCFullPath + @"\" + chapterTitle + " №" + i + ".ogg");
                    File.Move(BufferPath + @"\Result.mp4", lastCFullPath + @"\" + chapterTitle + " №" + i + ".mp4");

                    Thread.Sleep(1000);

                    Video video = new Video();
                    video.Snippet = new VideoSnippet();
                    video.Snippet.Title = bookName + " " + chapterTitle;
                    video.Snippet.Description = describe + " " + chapterTitle;
                    video.Snippet.Tags = ConcatMainSecondTags(mainTags, RandomTags(secondTags));
                    video.Snippet.CategoryId = "24"; // See https://developers.google.com/youtube/v3/docs/videoCategories/list
                    video.Status = new VideoStatus();
                    video.Status.PrivacyStatus = "public"; // or "private" or "public"
                    var filePath = lastCFullPath + @"\" + chapterTitle + " №" + i + ".mp4"; // Replace with path to actual movie file.
                    UploadVideo TEST = new UploadVideo();
                    TEST.Run(video, filePath);
                }
                else {
                    continue;
                }
              
                //ffmpegConcatComand = @" -f concat -safe 0 -i " + lastChapterTextFile + @" -c copy " + BufferPath + @"\Result.ogg";

                //Ffmpeg.Run(ffmpegConcatComand);


                //if (File.Exists(BufferPath + @"\Result.ogg"))
                //{
                //    File.Move(BufferPath + @"\Result.ogg", lastCFullPath + @"\" + chapterTitle + " №" + i + ".ogg");
                //}

                //RenameLastDownloadFile(chapterTitle);
            }
             
        }

   

        public int PrintTextContentFile(EpubTextContentFile textContentFile)
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
            if(list.Count == 0)
            {
                return 0;
            }

            int i = 0;
            foreach (string text in list)
            {
                i++;
                h(text,i);
            }
            return 1;
        }
        public bool WaitAndCheckDownload()
        {
            for (var j = 0; j < 30; j++)
            {
                if (File.Exists(basePath + @"\tts.ogg") && !(File.Exists(basePath + @"\tts.ogg.crdownload"))) { return false; }
                Thread.Sleep(1000);
            }
            return true;
        }
            public void h(string text, int i)
        {
            bool downloadFail = true;
            while (downloadFail){
                test.Read(text);
                downloadFail = WaitAndCheckDownload();
            }
  
            if (!File.Exists(lastChapterTextFile))
            {
                using(StreamWriter tw = File.CreateText(lastChapterTextFile))
                {
                    string resString = (BufferPath + @"\" + i + ".ogg").Replace(@"\", @"\\");
                    tw.WriteLine("file " + resString);
                }
         
            }
            else if (File.Exists(lastChapterTextFile))
            {
                using (var tw = new StreamWriter(lastChapterTextFile, true))
                {
                    string resString = (BufferPath + @"\" + i + ".ogg").Replace(@"\", @"\\");
                    tw.WriteLine("file " + resString);
                    tw.Close();
                }
            }

            File.Copy(basePath + @"\tts.ogg", BufferPath + @"\" + i + ".ogg");
            File.Move(basePath + @"\tts.ogg", lastCFullPath + @"\" + i + ".ogg");
       
        } 

        static List<string> SplitTextForCharLengthForWord(string str)
        {
            List<string> list = new List<string>();
            string text = "";
            string[] words = Regex.Split(str, @"(?<=[. ])");

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
        static string[] ConcatMainSecondTags(string str, string[] list)
        {

            string[] words = Regex.Split(str,",");
            
            list.Take(list.Count()).Concat(words.Take(words.Count()));

            return list;
        }

        static string[] RandomTags(string str)
        {
            List<string> list = new List<string>();
            string text = "";
            string[] words = Regex.Split(str, ",");
            
            var rnd = new Random();
            // Shuffle the array
            for (int i = 0; i < words.Length; ++i)
            {
                int randomIndex = rnd.Next(words.Length);
                string temp = words[randomIndex];
                words[randomIndex] = words[i];
                words[i] = temp;
            }

            for (var i = 0; i < words.Length - 1; i++)
            {
                text += words[i];
                list.Add(words[i]);
                if (words.Length - 1 != i && (text + words[i + 1]).Length > 300)
                {
                    break;
                }
            }

            return list.ToArray();
        }

        public void RenameLastDownloadFile(string fileName)
        {
            DirectoryInfo directory = new DirectoryInfo(basePath);
            try
            {
                var myFile = directory.GetFiles().OrderByDescending(f => f.LastWriteTime).First();

                File.Move(myFile.FullName, basePath + @"\" + fileName);
            }
            catch
            {

            }
        }

        public void ConcatFiles()
        {

        }
    }
}
