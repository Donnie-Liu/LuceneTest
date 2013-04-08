using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using Lucene.Net.Analysis;
using Lucene.Net.Analysis.PanGu;
using PanGu;

namespace LuceneTest
{
    public class Common
    {
        public class SplitContent {        
            public static string[] SplitWords( string content) {            
                List <string > strList = new List <string >();            
                Analyzer analyzer = new PanGuAnalyzer();            
                TokenStream tokenStream = analyzer.TokenStream("" , new StringReader (content));            
                Lucene.Net.Analysis. Token token = null ;            
                while ((token = tokenStream.Next()) != null ) { 
                    //Next继续分词 直至返回null                
                    strList.Add(token.TermText()); 
                    //得到分词后结果            
                }            
                return strList.ToArray();        
            }        
            //需要添加PanGu.HighLight.dll的引用        
            /// <summary>       
            /// /// 搜索结果高亮显示        /// 
            /// </summary>        
            /// <param name="keyword"> 关键字 </param>        
            /// <param name="content"> 搜索结果 </param>        
            /// <returns> 高亮后结果 </returns>        
            public static string HightLight( string keyword, string content) {            
                //创建HTMLFormatter,参数为高亮单词的前后缀            
                PanGu.HighLight. SimpleHTMLFormatter simpleHTMLFormatter = new PanGu.HighLight.SimpleHTMLFormatter ( "<font color=\"red\"><b>", "</b></font>" );            
                //创建 Highlighter ，输入HTMLFormatter 和 盘古分词对象Semgent            
                PanGu.HighLight. Highlighter highlighter = new PanGu.HighLight.Highlighter (simpleHTMLFormatter, new Segment ());            
                //设置每个摘要段的字符数            
                highlighter.FragmentSize = 50;            
                //获取最匹配的摘要段            
                return highlighter.GetBestFragment(keyword, content);        }    }
    }
}