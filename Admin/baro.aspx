<%@ Page Title="Baro İşlemleri" Language="C#" MasterPageFile="~/AdminMaster.master" AutoEventWireup="true" CodeFile="baro.aspx.cs" Inherits="Admin_Baro" %>


<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
    <link href="/CssDosyalari/adminbarod.css" rel="stylesheet"/>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="pageDisDiv">
        <div class="ustDiv">
            <div class="lineOrta" style="border-bottom: solid silver thin; margin-bottom: 2%;">
                <asp:Label CssClass="label" runat="server" Text="Yeni Oluştur" Font-Size="200%">Yeni Baro Oluştur</asp:Label>
            </div>
            <div class="line">
                <div class="lineSolDiv">
                    <asp:Label CssClass="label" runat="server">Baro Adı:</asp:Label>
                </div>
                <div class="lineSagDiv">
                    <asp:TextBox ID="txtbaroadi" CssClass="TexBoxCss" runat="server"></asp:TextBox>
                </div>
            </div>
           
            <div class="line">
                <div class="lineSolDiv">
                    <asp:Label CssClass="label" runat="server">Aktif:</asp:Label>
                </div>
                <div class="lineSagDiv">
                    <asp:CheckBox ID="CheckBox1" runat="server"/>
                </div>
            </div>
            <div class="lineOrta">
                <button runat="server" id="bynBaroKaydet" onserverclick="btnKaydet_Onclick" class="button" title="Baro Bilgisini Kaydet">
                    <i class="fa fa-floppy-o fa-2x"></i>Kaydet
                </button>
            </div>

        </div>
        
        

        <div class="altDiv">
            <asp:ListView ID="list2" runat="server">
                <ItemTemplate>
                    <div class="ListeDiv">
                        <div class="line">
                            <div class="lineSolDiv">
                                <asp:Label CssClass="label" runat="server" Font-Bold="True">Baro Adı: </asp:Label>
                            </div>
                            <div class="lineSagDiv">
                                <asp:Label ID="lblBaroAdi" runat="server" Text='<%#Eval("baroad") %>'></asp:Label>

                            </div>
                        </div>
                        <div class="line">
                            <div class="lineSolDiv">
                                <asp:Label CssClass="label" runat="server" Font-Bold="True">Aktif: </asp:Label>
                            </div>
                            <div class="lineSagDiv">
                                <asp:Label ID="lblAdktif" runat="server" Text='<%#Eval("aktif") %>'></asp:Label>
                            </div>
                        </div>
                       
                        <div class="lineOrtaSol">
                            <a href="baro.aspx?islem=aktif&baroid=<%#Eval("baroid") %>"> <img src="/image/checked.png" /> </a>
                        </div>
                    </div>
                </ItemTemplate>
            </asp:ListView>
        </div>
    </div>
    
    
    
    
    
    
    
    
    

    
</asp:Content>