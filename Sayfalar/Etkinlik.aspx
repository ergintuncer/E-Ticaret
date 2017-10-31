<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Etkinlik.aspx.cs" Inherits="Etkinlik" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
    <link href="etkinlik.css" rel="stylesheet"/>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="etkinlikbody" id="etkinlikbody">
        <div class="etkinlikust">
            <table class="ethinlikolusturtablo" id="ethinlikolusturtablo" border="0">
                <tbody>
                <tr>
                    <td class="tg-left">
                        <asp:Label ID="Label1" runat="server" Text="Başlık:"></asp:Label>
                    </td>
                    <td class="tg-midle">
                        <asp:TextBox ID="txt_baslik" CssClass="TextBox" runat="server"></asp:TextBox>

                        <asp:ScriptManager ID="ScriptManager1" runat="server">
                        </asp:ScriptManager>
                    </td>
                    <td class="tg-right" rowspan="6">
                        <asp:Image ID="img_etkinlikresmi" CssClass="etkinlikresmi" runat="server" ImageUrl="image/eventdefault.jpg"/>

                    </td>
                    <td class="tg-end" rowspan="6">
                        <asp:Button ID="btn_etkinlik_olustur" CssClass="buttonetkinlikolustur" runat="server" Text="Etkinlik Oluştur" OnClick="btn_etkinlik_olustur_Click"/>
                    </td>
                </tr>
                <tr>
                    <td class="tg-left">
                        <asp:Label ID="Label2" runat="server" Text="Açıklama:"></asp:Label>
                    </td>
                    <td class="tg-midle">
                        <asp:TextBox ID="txt_aciklama" CssClass="multiLineTextBox" runat="server" TextMode="MultiLine"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="tg-left">
                        <asp:Label ID="Label3" runat="server" Text="Etkinlik Resmi"></asp:Label>
                    </td>
                    <td class="tg-midle">
                        <asp:FileUpload ID="fluDosya" runat="server"/>
                        <%-- <asp:Button ID="ekle" CssClass="button" runat="server" Text="Kayıt Ol" OnClick="ekle_Click"  />--%>
                    </td>
                </tr>
                <tr>
                    <td class="tg-left">
                        <asp:Label ID="Label4" runat="server" Text="Konum:"></asp:Label>
                    </td>
                    <td class="tg-midle">
                        <asp:TextBox ID="txt_konum" CssClass="TextBox" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="tg-left">
                        <asp:Label ID="Label5" runat="server" Text="Tarih:"></asp:Label>
                    </td>
                    <td class="tg-midle">
                        <asp:TextBox ID="txt_tarih" CssClass="TextBox" runat="server" TextMode="Date"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="tg-left">
                        <asp:Label ID="Label6" runat="server" Text="Saat:"></asp:Label>
                    </td>
                    <td class="tg-midle">
                        <asp:TextBox ID="txt_saat" CssClass="TextBox" runat="server" TextMode="Time"></asp:TextBox>
                    </td>
                </tr>
                </tbody>
            </table>
        </div>
        <div class="etkinlikaltdiv">
            <asp:ListView ID="list1" runat="server">
                <ItemTemplate>
                    <div id="etkinlikdiv" class="etkinlikdiv">
                        <div class="etkinlikheader">
                            <%--asasasasasasasas--%>
                            <div class="etkinlikheadersol">
                                <asp:Image ID="img_etkinliksahibi" CssClass="etkinliksahibi" runat="server" ImageUrl='<%#Eval("resim") %>'/>
                                <asp:Label ID="lbl_etkinliksahibi" runat="server" Text='<%#Eval("adi_soyadi") %>'></asp:Label>
                            </div>
                            <div class="etkinlikheaderorta">
                                <asp:Label ID="lbl_etkinlikbaslik" runat="server" Text='<%#Eval("etkinlik_bas") %>'></asp:Label>
                            </div>
                            <div class="etkinlikheadersag">
                                <asp:Label ID="lbl_etkinliktarihi" runat="server" Text='<%#Eval("etkinlik_tarih") %>'></asp:Label>
                                <asp:Label ID="lbl_etkinliksaati" runat="server" Text='<%#Eval("etkinlik_saat") %>'></asp:Label>
                            </div>
                        </div>
                        <div class="etkinlikicerikdiv">
                            <div class="etkinliksol">
                                <asp:Image ID="img_etkinlik" CssClass="etkinlikposter" runat="server" ImageUrl='<%#Eval("etkinlik_resim") %>'/>
                            </div>
                            <div class="etkinliksag">
                                <asp:Label ID="lbl_etkinlikaciklama" CssClass="lbletkinlikaciklama" runat="server" Text='<%#Eval("etkinlik_icerik") %>' Font-Strikeout="False"></asp:Label>
                            </div>
                        </div>
                        <div class="etkinlikfooter">
                            <asp:Label ID="lbl_etkinlikkonumu" CssClass="lbl_etkinlikkonumu" runat="server" Text='<%#Eval("etkinlik_konum") %>'></asp:Label>
                        </div>
                    </div>

                </ItemTemplate>
            </asp:ListView>

        </div>
    </div>
</asp:Content>