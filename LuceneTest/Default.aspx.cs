using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using PanGu;
using Lucene;
using PanGu.HighLight;
using Lucene.Net.Analysis.PanGu;
using Lucene.Net.Store;
using Lucene.Net.Index;
using Lucene.Net.Documents;
using Lucene.Net.Search;

namespace LuceneTest
{
    public partial class _Default : System.Web.UI.Page
    {
                
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }



        protected void btnSegment_Click(object sender, EventArgs e)
        {
            String filePath = @"d:\test.txt";
            FileStream fs = new FileStream(filePath, FileMode.Open);
            StreamReader rs = new StreamReader(fs);
            String txt = rs.ReadToEnd();

            rs.Close();
            fs.Close();

            PanGu.Segment.Init();
            Segment segment = new Segment();

            ICollection<WordInfo> words = segment.DoSegment(txt);

            String s = "";
            foreach (WordInfo word in words)
            {
                s += word.Word + "{POS:" + word.Pos + " Position:" + word.Position + " Rank:" + word.Rank + " Freqency:" + word.Frequency + "}<br> ";
            }
            WordInfo x = words.ElementAt(4);

            MsgLbl.Text = s;

        }

        protected List<String> PhraseTemplate(ICollection<WordInfo> words)
        {
            List<String> keywordslist = new List<string>();
            int count = words.Count;
            int i=0;
            while (i < count)
            {
                WordInfo first = words.ElementAt(i);
                WordInfo second = words.ElementAt(i + 1);
                WordInfo third = words.ElementAt(i + 2);

            }

            return keywordslist;
        }

//        protected void CreateBtn1_Click(object sender, EventArgs e)
//        {
//             string indexPath = @"D:\" ; //索引文档保存位置
//             FSDirectory directory = FSDirectory .Open( new DirectoryInfo (indexPath), new NativeFSLockFactory ());
//             bool isUpdate = IndexReader .IndexExists(directory); //是否存在索引库文件夹以及索引库特征文件 
//             if (isUpdate) {                //如果索引目录被锁定（比如索引过程中程序异常退出或另一进程在操作），则解锁  
//                 if (IndexWriter .IsLocked(directory)) {
//                     IndexWriter .Unlock(directory); 
//                 }
//             }
//            //创建索引库对象   new PanGuAnalyzer()指定使用盘古分词进行切词 
//            IndexWriter writer = new IndexWriter(directory, new PanGuAnalyzer (), !isUpdate, Lucene.Net.Index.IndexWriter . MaxFieldLength.UNLIMITED);
//            Document document = new Document(); //new 一篇文档 对象
//                //所有字段的值都将以字符串类型保存
//                //Field.Store表示是否保存字段原值。指定Field.Store.YE的字段在检索时才能用document.Get取出来值  NOT_ANALYZED指定不按照分词后的结果保存
////                document.Add( new Field ( "id", book.Id.ToString(), Field .Store .YES, Field .Index .NOT_ANALYZED));
////                document.Add( new Field ( "title", book.Title, Field .Store .YES, Field .Index .ANALYZED, Lucene.Net.Documents.Field .TermVector .WITH_POSITIONS_OFFSETS));
//                //Field.Index. ANALYZED指定文章内容按照分词后结果保存  否则无法实现后续的模糊查找  WITH_POSITIONS_OFFSETS指示不仅保存分割后的词 还保存词之间的距离
//                document.Add( new Field ( "content", this.MsgLbl.Text, Field .Store .YES, Field. Index .ANALYZED, Lucene.Net.Documents.Field .TermVector .WITH_POSITIONS_OFFSETS));
//                writer.AddDocument(document); //文档写入索引库
            
//            writer.Close();
//            directory.Close(); //不要忘了Close，否则索引结果搜不到  
//        }

//        protected void btnSearch_Click(object sender, EventArgs e)
//        {
//            string indexPath = @"D:\"; 
//            FSDirectory directory = FSDirectory.Open(new DirectoryInfo(indexPath), new NoLockFactory()); 
//            IndexReader reader = IndexReader.Open(directory, true); 
//            IndexSearcher searcher = new IndexSearcher(reader); //Index：索引            //搜索条件            
//            PhraseQuery query = new PhraseQuery();            
//            //把用户输入的关键字进行分词            
//            foreach (string word in Common.SplitContent .SplitWords(tbSearch.Text.ToLower())) {
//                query.Add( new Term ( "content", word));
//            }            
//            query.SetSlop(100); //指定关键词相隔最大距离            
//            //TopScoreDocCollector盛放查询结果的容器            
//            TopScoreDocCollector collector = TopScoreDocCollector .create(1000, true );            
//            searcher.Search(query, null , collector);
//            //根据query查询条件进行查询，查询结果放入collector容器            
//            //TopDocs 指定0到GetTotalHits() 即所有查询结果中的文档            
//            ScoreDoc [] docs = collector.TopDocs(0, collector.GetTotalHits()).scoreDocs;            
  
//                //搜索关键字高亮显示                
//                MsgLbl.Text = Common.SplitContent .HightLight(tbSearch.Text, docs[0].Get("content" ));                
          
//        }    
        }
}

