<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Profil.aspx.cs" Inherits="Profil" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
    <link href="profil.css" rel="stylesheet"/>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <div id="ustprofil" class="ustprofil">
        <table class="ustprofiltablo" id="ustprofiltablo" border="0">
            <tbody>
            <tr>
                <th class="tg-right" rowspan="7">
                    <asp:Image ID="profilresmi" CssClass="profilresmi" runat="server" ImageUrl="image/1.jpg" Width="150px" Height="150px"/>
                    <%-- Fatih bu image url değişecek Yandaki kod yukardaakiyle yer değişecek--%> <%--ImageUrl='<%#Eval("resim") %>'--%>
                </th>
                <th class="tg-midle">
                    <asp:Label ID="Label1" runat="server" Text="Adı:" Font-Bold="False"></asp:Label>
                </th>
                <th class="tg-left">
                    <asp:Label ID="lbladi" runat="server" CssClass="Label" Font-Bold="False"></asp:Label>
                </th>
            </tr>
            <tr>
                <td class="tg-midle">
                    <asp:Label ID="Label2" runat="server" Text="Soyadı:"></asp:Label>
                </td>
                <td class="tg-left">
                    <asp:Label ID="lblsoyadi" runat="server" Text=""></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="tg-midle">
                    <asp:Label ID="Label3" runat="server" Text="Doğum Tarihi:"></asp:Label>
                </td>
                <td class="tg-left">
                    <asp:Label ID="lblyasi" runat="server" Text=""></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="tg-midle">
                    <asp:Label ID="Label4" runat="server" Text="Memleketi:"></asp:Label>
                </td>
                <td class="tg-left">
                    <asp:Label ID="lblsehir" runat="server" Text=""></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="tg-midle">
                    <asp:Label ID="Label5" runat="server" Text="Üniversitesi:"></asp:Label>
                </td>
                <td class="tg-left">
                    <asp:Label ID="lbluniversitesi" runat="server" Text=""></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="tg-midle">
                    <asp:Label ID="Label6" runat="server" Text="Fakültesi:"></asp:Label>
                </td>
                <td class="tg-left">
                    <asp:Label ID="lblfakultesi" runat="server" Text=""></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="tg-midle">
                    <asp:Label ID="Label7" runat="server" Text="Bölümü:"></asp:Label>
                </td>
                <td class="tg-left">
                    <asp:Label ID="lblbolumu" runat="server" Text=""></asp:Label>
                </td>
            </tr>
            </tbody>

        </table>
    </div>
    <div id="altprofil" class="altprofil">
        <div id="profilheader" class="profilheader">
            <table class="headertablo" id="headertablo">
                <tr>
                    <th class="tg-fa" id="duzenle-tg-fa">
                        <i class="fa fa-pencil-square-o fa-2x"> </i><span> Düzenle</span> 
                    </th>
                    <th class="tg-fa">
                        <i class="fa fa-camera-retro fa-2x "> </i> <span>Fotoğraflar</span> 
                    </th>
                    <th class="tg-fa">
                        <i class="fa fa-address-book fa-2x "> </i> <span>Kişiler</span> 
                    </th>
                    <th class="tg-fa">
                        <i class="fa fa-low-vision fa-2x "> </i> <span>Görünmez</span> 
                    </th>
                    <th class="tg-fa">

                        <i class="fa fa-mortar-board fa-2x "> </i> <span>Mezuniyet</span> 
                    </th>
                </tr>

            </table>
        </div>
        <div id="profilDuvar" class="profilDuvar">
            <asp:ListView ID="list1" runat="server">
                <ItemTemplate>
                    <div class="profilPaylasim" id="profilPaylasim">
                        <div class="paylasimHeader">
                            <asp:Image ID="imgpaylasimHeaderResim" CssClass="imgpaylasimHeaderResim" runat="server" ImageUrl='<%#Eval("resim") %>'/>
                            <asp:Label ID="lblpaylasimHeaderAdi" CssClass="lblpaylasimHeaderAdi" runat="server" Text='<%#Eval("adi_soyadi") %>'></asp:Label>
                        </div>
                        <div class="paylasimIcerik">
                            <asp:Label ID="lblPaylasimIcerik" CssClass="lblPaylasimIcerik" runat="server" Text='<%#Eval("icerik") %>'></asp:Label>
                        </div>
                        <div class="paylasimFooter">
                            <asp:ImageButton ID="imgPaylasimiBegenButton" CssClass="imgPaylasimiBegenButton" OnClick="imgPaylasimiBegenButton_Click" ImageUrl="image/liked.png" runat="server"/> <%-- Beğen butonuna tıklanınca url "image/liked.png" olacak --%>
                            <a href="Profil.aspx?islem=sil&id=<%#Eval("ID") %>"><img src="image/1482007936_Close_Icon.png" /></a>
                            <asp:Label ID="lblBegenmeSayisi" CssClass="lblBegenmeSayisi" runat="server" Text='<%#Eval("begenmesayisi") %>'></asp:Label>
                            <asp:Label ID="lblPaylasimTarihi" CssClass="lblPaylasimTarihi" runat="server" Text='<%#Eval("tarih_saat") %>'></asp:Label>
                        </div>
                    </div>
                </ItemTemplate>
            </asp:ListView>
        </div>
    </div>
</asp:Content>