<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
    <link href="default.css" rel="stylesheet"/>
   
</asp:Content>


<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div id="paylasimYap" class="paylasimYap">
        <div class="paylasimYapUst">
             <asp:Image ID="imgPaylasimResimOnizleme" CssClass="imgPaylasimResimOnizleme" ImageUrl="image/irvin.jpg" runat="server"  Visible="True"/> <%--varsayılan visible false olacak resim yükleince önizleme olarak visible true olacak paylaşım yapılınca url si temizlenip false yapılacak--%>
            <asp:TextBox ID="txt_paylasimIcerik" CssClass="multiLineTextBox" runat="server" TextMode="MultiLine"></asp:TextBox>
        </div>
        <div class="paylasimYapAlt">
            <asp:FileUpload ID="fluDosya" runat="server" CssClass="paylasimresimekle"/>
            <asp:Button ID="paylas" CssClass="paylasButton" runat="server" Text="Paylaş" OnClick="paylas_Click"/>
        </div>
    </div>

     <asp:ListView ID="list1" runat="server">
      <ItemTemplate>
       <div class="AnasayfaPaylasim" id="AnasayfaPaylasim">
        <div class="paylasimHeader" id="paylasimHeader">
            <asp:Image ID="imgpaylasimHeaderResim" CssClass="imgpaylasimHeaderResim" runat="server" ImageUrl='<%#Eval("resim") %>'/>
            <asp:Label ID="lblpaylasimHeaderAdi" CssClass="lblpaylasimHeaderAdi" runat="server" Text='<%#Eval("adi_soyadi") %>'></asp:Label>
        </div>
        <div class="paylasimIcerik">
            <asp:Image ID="imgpaylasimresim" CssClass="imgpaylasimresim" ImageUrl='<%#Eval("p_resim") %>' runat="server" />
            <asp:Label ID="lblPaylasimIcerik" CssClass="lblPaylasimIcerik" runat="server" Text='<%#Eval("icerik") %>'></asp:Label>
        </div>
        <div class="paylasimFooter">
           <%-- <asp:ImageButton ID="imgPaylasimiBegenButton" CssClass="imgPaylasimiBegenButton" ImageUrl="image/liked.png" runat="server" />--%> <%-- Beğen butonuna tıklanınca url "image/liked.png" olacak --%>
            <a href="Default.aspx?islem=like&id=<%#Eval("ID") %>" id="begen" onclick="begen_Click">
                        <img src="image/1482007936_Close_Icon.png" id="begenpic" /></a>
             <asp:Label ID="lblBegenmeSayisi" CssClass="lblBegenmeSayisi" runat="server" Text='<%#Eval("begenmesayisi") %>'></asp:Label>
            <asp:Label ID="lblPaylasimTarihi" CssClass="lblPaylasimTarihi" runat="server" Text='<%#Eval("tarih_saat") %>'></asp:Label>
        </div>
      </div>
      </ItemTemplate>
  </asp:ListView>
</asp:Content>