<%@ Page Title="主页" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeBehind="Default.aspx.cs" Inherits="LuceneTest._Default" %>

<%@ Import Namespace="Lucene.Net.Index" %>
<%@ Import Namespace="Lucene.Net.Analysis.Standard" %>
<%@ Import Namespace="Lucene.Net.Documents" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <h2>
        &nbsp;</h2>
    <p>
        <asp:Button ID="btnSegment" runat="server" onclick="btnSegment_Click" 
            Text="分词" />
    </p>
    <p>
        <asp:Label ID="MsgLbl" runat="server"></asp:Label>
    </p>
    <p>
        &nbsp;</p>
    </asp:Content>
