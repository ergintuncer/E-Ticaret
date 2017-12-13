<%@ Page Title="Banla HEsap Türü" Language="C#" MasterPageFile="~/AnaSayfaMaster.master" AutoEventWireup="true" CodeFile="banka-hesap-tur.aspx.cs" Inherits="Kullanici_banka_hesap_tur" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
    <link href="/CssDosyalari/bankaHesapTurug.css" rel="stylesheet"/>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
     <div class="pageDisDiv">
        <div class="ustDiv">
            <div class="lineOrta" style="border-bottom: solid silver thin; margin-bottom: 2%;">
                <asp:Label CssClass="label" runat="server" Text="Yeni Hesap Türü" Font-Size="200%">Yeni Hesap Türü Oluştur</asp:Label>
            </div>
            <div class="line">
                <div class="lineSolDiv">
                    <asp:Label CssClass="label" runat="server">Hesap Türü:</asp:Label>
                </div>
                <div class="lineSagDiv">
                    <asp:TextBox ID="txtHesapTur" CssClass="TexBoxCss" runat="server"></asp:TextBox>
                </div>
            </div>

            <div class="line">
                <div class="lineSolDiv">
                    <asp:Label CssClass="label" runat="server">Hesap Türü Hakkında:</asp:Label>
                </div>
                <div class="lineSagDiv">
                    <asp:TextBox ID="txtHesapTurAciklama" CssClass="TexBoxCss" runat="server"></asp:TextBox>
                </div>
            </div>
           
            <div class="lineOrta">
                <button runat="server" id="btnKaydet" class="btn btn-outline-success" OnServerClick="btnKaydet_Click" Text="Kaydet">Kaydet </button>
            
            </div>

        </div>


        <div class="altDiv">
            <%--            <asp:ListView ID="list2" runat="server">
                <ItemTemplate>--%>
            <div class="ListeDiv">
                <div class="line">
                    <div class="lineSolDiv">
                        <asp:Label CssClass="label" runat="server">Hesap Türü: </asp:Label>
                    </div>
                    <div class="lineSagDiv">
                        <asp:Label ID="lblBankaHesapTuru" runat="server" Text='<%#Eval("hesaptur") %>'></asp:Label>
                    </div>
                </div>
                <div class="line">
                    <div class="lineSolDiv">
                        <asp:Label CssClass="label" runat="server">Hakkında: </asp:Label>
                    </div>
                    <div class="lineSagDiv">
                        <asp:Label ID="lblBankaHesapAciklama" runat="server" Text='<%#Eval("aciklama") %>'></asp:Label>
                    </div>
                </div>
            </div>
            <%--                </ItemTemplate>
            </asp:ListView>--%>
        </div>
    </div>
    
    

    
    
    
    

   
</asp:Content>

