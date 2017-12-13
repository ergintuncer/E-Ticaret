<%@ Page Title="Yeni Banka" Language="C#" MasterPageFile="~/AnaSayfaMaster.master" AutoEventWireup="true" CodeFile="bankabilgi.aspx.cs" Inherits="Kullanici_paratransferi" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
   <link href="/CssDosyalari/BankaBilgii.css" rel="stylesheet"/>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    
    
    <div class="pageDisDiv">
        <div class="ustDiv">
            <div class="lineOrta" style="border-bottom: solid silver thin; margin-bottom: 2%;">
                <asp:Label CssClass="label" runat="server" Text="Yeni Banka Oluştur" Font-Size="200%">Yeni Banka Oluştur</asp:Label>
            </div>
            <div class="line">
                <div class="lineSolDiv">
                    <asp:Label CssClass="label" runat="server">Banka:</asp:Label>
                </div>
                <div class="lineSagDiv">
                     <asp:TextBox ID="txtBankaAdi" CssClass="TexBoxCss"  runat="server"></asp:TextBox>
                </div>
            </div>
           
            <div class="line">
                <div class="lineSolDiv">
                    <asp:Label CssClass="label" runat="server">Şube:</asp:Label>
                </div>
                <div class="lineSagDiv">
                    <asp:TextBox ID="txtBankaSube"  CssClass="TexBoxCss"  runat="server"></asp:TextBox>
                </div>
            </div>
            <div class="line">
                <div class="lineSolDiv">
                    <asp:Label CssClass="label" runat="server">Şube Kodu:</asp:Label>
                </div>
                <div class="lineSagDiv">
                    <asp:TextBox ID="txtBankaSubeKodu" CssClass="TexBoxCss" runat="server"></asp:TextBox>
                </div>
            </div>
            <div class="line">
                <div class="lineSolDiv">
                    <asp:Label CssClass="label" runat="server">Telefon Kodu:</asp:Label>
                </div>
                <div class="lineSagDiv">
                    <asp:TextBox ID="txtBankaTelefonKodu"  CssClass="TexBoxCss" runat="server"></asp:TextBox>
                </div>
            </div>
            <div class="line">
                <div class="lineSolDiv">
                    <asp:Label CssClass="label" runat="server">Telefon No:</asp:Label>
                </div>
                <div class="lineSagDiv">
                    <asp:TextBox ID="txtBankaTelefonNo" CssClass="TexBoxCss"  runat="server" TextMode="Phone"></asp:TextBox>
                </div>
            </div>
            <div class="line">
                <div class="lineSolDiv">
                    <asp:Label CssClass="label" runat="server">Banka Aktif:</asp:Label>
                </div>
                <div class="lineSagDiv">
                    <asp:CheckBox ID="chckBankaAktif" runat="server"/>
                </div>
            </div>
            <div class="line">
                <div class="lineSolDiv">
                    <asp:Label CssClass="label" runat="server">Banka Adres:</asp:Label>
                </div>
                <div class="lineSagDiv">
                    <asp:TextBox ID="txtBankaAdres" CssClass="TextBoxCssMulti" runat="server" TextMode="MultiLine"></asp:TextBox>
                </div>
            </div>
            <div class="line">
                <div class="lineSolDiv">
                    <asp:Label CssClass="label" runat="server">Banka Hakkında:</asp:Label>
                </div>
                <div class="lineSagDiv">
                    <asp:TextBox ID="txtBankaAciklama" CssClass="TextBoxCssMulti" runat="server" TextMode="MultiLine"></asp:TextBox>
                </div>
            </div>
            <div class="lineOrta">
                 <button runat="server" id="btnKaydet" class="btn btn-outline-success" OnServerClick="btnKaydet_Click" Text="Kaydet">Kaydet </button>

            </div>

        </div>
                   
                       
        <div class="altDiv">
            <asp:ListView ID="list2" runat="server">
                <ItemTemplate>
                    <div class="ListeDiv">
                        <div class="line">
                            <div class="lineSolDiv">
                                <asp:Label CssClass="label" runat="server">Banka Adı: </asp:Label>
                            </div>
                            <div class="lineSagDiv"> 
                                <asp:Label ID="lblil" runat="server" Text='<%#Eval("bankaad") %>'></asp:Label>
                            </div>
                        </div><div class="line">
                            <div class="lineSolDiv">
                                <asp:Label CssClass="label" runat="server">Banka Şube: </asp:Label>
                            </div>
                            <div class="lineSagDiv">
                                <asp:Label ID="lblilce"  runat="server" Text='<%#Eval("bankasubead") %>'></asp:Label>

                            </div>
                        </div>
                        <div class="line">
                            <div class="lineSolDiv">
                                <asp:Label CssClass="label" runat="server">Şube Kodu: </asp:Label>
                            </div>
                            <div class="lineSagDiv">
                                <asp:Label ID="lbladresadi" runat="server" Text='<%#Eval("bankasubekod") %>'></asp:Label>
                            </div>
                        </div>
                        <div class="line">
                            <div class="lineSolDiv">
                                <asp:Label CssClass="label" runat="server">Telefon: </asp:Label>
                            </div>
                            <div class="lineSagDiv">
                                <asp:Label ID="lbladres" runat="server" Text='<%#Eval("bankasubetel1") %>'></asp:Label>
                            </div>
                        </div>
                        <div class="line">
                            <div class="lineSolDiv">
                                <asp:Label CssClass="label" runat="server">Adres: </asp:Label>
                            </div>
                            <div class="lineSagDiv">
                                <asp:Label ID="lblaciklama" runat="server" Text='<%#Eval("bankasubeadres") %>'></asp:Label>
                            </div>
                        </div>
                        <div class="line">
                            <div class="lineSolDiv">
                                <asp:Label CssClass="label" runat="server">Açıklama: </asp:Label>
                            </div>
                            <div class="lineSagDiv">
                                <asp:Label ID="lblaktif" runat="server" Text='<%#Eval("aciklama") %>'></asp:Label>
                            </div>
                        </div>
                        <div class="lineOrtaSol">
                            <button runat="server" id="aktiflik" onserverclick="Aktiflik_OnClick" class="buttonOnayla" title="Aktif mi?">
                                <i class="fa fa-check fa-2x"> </i>
                            </button>
                        </div>
                    </div>
                </ItemTemplate>
            </asp:ListView>
        </div>
    </div>
</asp:Content>