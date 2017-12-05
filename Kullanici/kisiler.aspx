<%@ Page Title="Kişi işlemleri" Language="C#" MasterPageFile="~/AnaSayfaMaster.master" AutoEventWireup="true" CodeFile="kisiler.aspx.cs" Inherits="Kullanici_kisiler" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
      <div class="pageDisDiv">
        <div class="ustDiv">
            <div class="lineOrta" style="border-bottom: solid silver thin; margin-bottom: 2%;">
                <asp:Label CssClass="label" runat="server" Text="Yeni Kişi Ekle" Font-Size="200%">Yeni kişi ekle</asp:Label>
            </div>
            <div class="line">
                <div class="lineSolDiv">
                    <asp:Label CssClass="label" runat="server">Adı:</asp:Label>
                </div>
                <div class="lineSagDiv">
                    <asp:TextBox ID="txtAdi"  CssClass="TexBoxCss"  runat="server"></asp:TextBox>
                </div>
            </div>
            <div class="line">
                <div class="lineSolDiv">
                    <asp:Label CssClass="label" runat="server">Soyadı:</asp:Label>
                </div>
                <div class="lineSagDiv">
                    <asp:TextBox ID="txtSoyadi"  CssClass="TexBoxCss"  runat="server"></asp:TextBox>
                </div>
            </div>
            <div class="line">
                <div class="lineSolDiv">
                    <asp:Label CssClass="label" runat="server">TC No: </asp:Label>
                </div>
                <div class="lineSagDiv">
                    <asp:TextBox ID="txtTcNo"  CssClass="TexBoxCss"  runat="server"></asp:TextBox>
                </div>
            </div><div class="line">
                <div class="lineSolDiv">
                    <asp:Label CssClass="label" runat="server">Kişi Türü:</asp:Label>
                </div>
                <div class="lineSagDiv">
                    <asp:DropDownList ID="drpKisiTuru" runat="server" CssClass="drplist" AutoPostBack="true">
                        <asp:ListItem Text="Kişi Türü" Value="Kişi Türü"></asp:ListItem>
                    </asp:DropDownList>
                </div>
            </div>
            <div class="line">
                <div class="lineSolDiv">
                    <asp:Label CssClass="label" runat="server">İl:</asp:Label>
                </div>
                <div class="lineSagDiv">
                    <asp:DropDownList ID="drpIl" runat="server" CssClass="drplist" AutoPostBack="true" OnSelectedIndexChanged="drpIl_SelectedIndexChanged">
                        <asp:ListItem Text="İl" Value="İl"></asp:ListItem>
                    </asp:DropDownList>
                </div>
            </div>
            <div class="line">
                <div class="lineSolDiv">
                    <asp:Label CssClass="label" runat="server">İlçe:</asp:Label>
                </div>
                <div class="lineSagDiv">
                    <asp:DropDownList ID="drpIlce" runat="server" CssClass="drplist" AutoPostBack="true">
                        <asp:ListItem Text="İlçe" Value="İlçe"></asp:ListItem>
                    </asp:DropDownList>
                </div>
            </div>
            <div class="line">
                <div class="lineSolDiv">
                    <asp:Label CssClass="label" runat="server">Telefon Adı:</asp:Label>
                </div>
                <div class="lineSagDiv">
                    <asp:TextBox ID="txtTelefonAdi"  CssClass="TexBoxCss"  runat="server"></asp:TextBox>
                </div>
            </div>
            <div class="line">
                <div class="lineSolDiv">
                    <asp:Label CssClass="label" runat="server">Telefon No:</asp:Label>
                </div>
                <div class="lineSagDiv">
                    <asp:TextBox ID="txtTelefonNo"  CssClass="TexBoxCss"  runat="server" TextMode="Phone"></asp:TextBox>
                </div>
            </div>
            <div class="line">
                <div class="lineSolDiv">
                    <asp:Label CssClass="label" runat="server">Mail:</asp:Label>
                </div>
                <div class="lineSagDiv">
                    <asp:TextBox ID="txtMail" CssClass="TexBoxCss" runat="server" TextMode="Email"></asp:TextBox>
                </div>
            </div>
            
            

            
            <div class="line">
                <div class="lineSolDiv">
                    <asp:Label CssClass="label" runat="server">Bakiye:</asp:Label>
                </div>
                <div class="lineSagDiv">
                    <asp:TextBox ID="txtBakiye" CssClass="TexBoxCss" runat="server" TextMode="Number"></asp:TextBox>
                </div>
            </div>
            <div class="line">
                <div class="lineSolDiv">
                    <asp:Label CssClass="label" runat="server">Adres Adı:</asp:Label>
                </div>
                <div class="lineSagDiv">
                    <asp:TextBox ID="txtAdresAdi" CssClass="TexBoxCss" runat="server"></asp:TextBox>
                </div>
            </div>
            <div class="line">
                <div class="lineSolDiv">
                    <asp:Label CssClass="label" runat="server">Adres:</asp:Label>
                </div>
                <div class="lineSagDiv">
                    <asp:TextBox ID="txtAdres"  CssClass="TextBoxCssMulti" runat="server" TextMode="MultiLine"></asp:TextBox>
                </div>
            </div>
            
            <div class="lineOrta">
                <button runat="server" id="btnKaydet" class="button" OnServerClick="btnKaydet_Click" Text="Kaydet">
                    <i class="fa fa-save fa-2x"></i>Kaydet
                </button>
            </div>

        </div>
                   
                       
        <div class="altDiv">
            <asp:ListView ID="list2" runat="server">
                <ItemTemplate>
                    <div class="ListeDiv">
                        <div class="line">
                            <div class="lineSolDiv">
                                <asp:Label CssClass="label" runat="server">Adı: </asp:Label>
                            </div>
                            <div class="lineSagDiv"> 
                                <asp:Label ID="lblil" runat="server" Text='<%#Eval("ad") %>'></asp:Label>
                            </div>
                        </div><div class="line">
                            <div class="lineSolDiv">
                                <asp:Label CssClass="label" runat="server">Soyadı: </asp:Label>
                            </div>
                            <div class="lineSagDiv">
                                <asp:Label ID="lblilce"  runat="server" Text='<%#Eval("soyad") %>'></asp:Label>

                            </div>
                        </div>
                        <div class="line">
                            <div class="lineSolDiv">
                                <asp:Label CssClass="label" runat="server">Tc No: </asp:Label>
                            </div>
                            <div class="lineSagDiv">
                                <asp:Label ID="lbladresadi" runat="server" Text='<%#Eval("tck") %>'></asp:Label>
                            </div>
                        </div>
                        <div class="line">
                            <div class="lineSolDiv">
                                <asp:Label CssClass="label" runat="server">İl: </asp:Label>
                            </div>
                            <div class="lineSagDiv">
                                <asp:Label ID="lbladres" runat="server" Text='<%#Eval("il") %>'></asp:Label>
                            </div>
                        </div>
                        <div class="line">
                            <div class="lineSolDiv">
                                <asp:Label CssClass="label" runat="server">İlçe: </asp:Label>
                            </div>
                            <div class="lineSagDiv">
                                <asp:Label ID="lblaciklama" runat="server" Text='<%#Eval("ilce") %>'></asp:Label>
                            </div>
                        </div>
                        <div class="line">
                            <div class="lineSolDiv">
                                <asp:Label CssClass="label" runat="server">Telefon Adı: </asp:Label>
                            </div>
                            <div class="lineSagDiv">
                                <asp:Label ID="Label1" runat="server" Text='<%#Eval("telefonad") %>'></asp:Label>
                            </div>
                        </div>
                        <div class="line">
                            <div class="lineSolDiv">
                                <asp:Label CssClass="label" runat="server">Telefon No: </asp:Label>
                            </div>
                            <div class="lineSagDiv">
                                <asp:Label ID="lblaktif" runat="server" Text='<%#Eval("telefonno") %>'></asp:Label>
                            </div>
                        </div>
                        <div class="line">
                            <div class="lineSolDiv">
                                <asp:Label CssClass="label" runat="server">E-Mail: </asp:Label>
                            </div>
                            <div class="lineSagDiv">
                                <asp:Label ID="Label2" runat="server" Text='<%#Eval("email") %>'></asp:Label>
                            </div>
                        </div>
                        <div class="line">
                            <div class="lineSolDiv">
                                <asp:Label CssClass="label" runat="server">Kişi Türü: </asp:Label>
                            </div>
                            <div class="lineSagDiv">
                                <asp:Label ID="Label3" runat="server" Text='<%#Eval("kisituru") %>'></asp:Label>
                            </div>
                        </div>  <div class="line">
                            <div class="lineSolDiv">
                                <asp:Label CssClass="label" runat="server">Bakiye: </asp:Label>
                            </div>
                            <div class="lineSagDiv">
                                <asp:Label ID="Label4" runat="server" Text='<%#Eval("bakiye") %>'></asp:Label>
                            </div>
                        </div>
                        <div class="line">
                            <div class="lineSolDiv">
                                <asp:Label CssClass="label" runat="server">Adres Adı: </asp:Label>
                            </div>
                            <div class="lineSagDiv">
                                <asp:Label ID="Label5" runat="server" Text='<%#Eval("adresad") %>'></asp:Label>
                            </div>
                        </div>
                        <div class="line">
                            <div class="lineSolDiv">
                                <asp:Label CssClass="label" runat="server">Adres: </asp:Label>
                            </div>
                            <div class="lineSagDiv">
                                <asp:Label ID="Label6" runat="server" Text='<%#Eval("adres") %>'></asp:Label>
                            </div>
                        </div>
                    </div>
                </ItemTemplate>
            </asp:ListView>
        </div>
    </div>

</asp:Content>

