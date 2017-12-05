<%@ Page Title="Para İşlemleri" Language="C#" MasterPageFile="~/AnaSayfaMaster.master" AutoEventWireup="true" CodeFile="para-hareket.aspx.cs" Inherits="Kullanici_para_hareket" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
     <div class="pageDisDiv">
        <div class="ustDiv">
            <div class="lineOrta" style="border-bottom: solid silver thin; margin-bottom: 2%;">
                <asp:Label CssClass="label" runat="server" Text="Para Hareket Bilgisi" Font-Size="200%">Para Hareket Bilgisi</asp:Label>
            </div>
            <div class="line">
                <div class="lineSolDiv">
                    <asp:Label CssClass="label" runat="server">İşlem Türü:</asp:Label>
                </div>
                <div class="lineSagDiv">
                    <asp:DropDownList ID="drpIslemTuru" runat="server" CssClass="drplist" AutoPostBack="true" OnSelectedIndexChanged="drpIslemTuru_SelectedIndexChanged">
                        <asp:ListItem Text="İşlem Türü" Value="İşlem Türü"></asp:ListItem>
                    </asp:DropDownList>
                </div>
            </div>
            <div class="line">
                <div class="lineSolDiv">
                    <asp:Label CssClass="label" runat="server">Gönderen:</asp:Label>
                </div>
                <div class="lineSagDiv">
                    <asp:DropDownList ID="drpGonderen" runat="server" CssClass="drplist" AutoPostBack="true" OnSelectedIndexChanged="drpGonderen_SelectedIndexChanged">
                        <asp:ListItem Text="Gönderen" Value="Gönderen"></asp:ListItem>
                    </asp:DropDownList>
                </div>
            </div>
            <div class="line">
                <div class="lineSolDiv">
                    <asp:Label CssClass="label" runat="server">Makbuz No:</asp:Label>
                </div>
                <div class="lineSagDiv">
                    <asp:TextBox ID="txtMakbuzNo"  CssClass="TexBoxCss"  runat="server" TextMode="Number"></asp:TextBox>
                </div>
            </div>
            <div class="line">
                <div class="lineSolDiv">
                    <asp:Label CssClass="label" runat="server">Alıcı:</asp:Label>
                </div>
                <div class="lineSagDiv">
                    <asp:DropDownList ID="drpAlici" runat="server" CssClass="drplist" AutoPostBack="true" OnSelectedIndexChanged="drpAlici_SelectedIndexChanged">
                        <asp:ListItem Text="Alıcı" Value="Alıcı"></asp:ListItem>
                    </asp:DropDownList>
                </div>
            </div>
            <div class="line">
                <div class="lineSolDiv">
                    <asp:Label CssClass="label" runat="server">Tarih Saat:</asp:Label>
                </div>
                <div class="lineSagDiv">
                    <asp:TextBox ID="txtTarihSaat" CssClass="TexBoxCss" runat="server" TextMode="Date"></asp:TextBox>
                </div>
            </div>
            <div class="line">
                <div class="lineSolDiv">
                    <asp:Label CssClass="label" runat="server">Tutar:</asp:Label>
                </div>
                <div class="lineSagDiv">
                    <asp:TextBox ID="txtTutar" CssClass="TexBoxCss" runat="server" TextMode="Number"></asp:TextBox>
                </div>
            </div>
            <div class="line">
                <div class="lineSolDiv">
                    <asp:Label CssClass="label" runat="server">Açıklama:</asp:Label>
                </div>
                <div class="lineSagDiv">
                    <asp:TextBox ID="txtAciklama"  CssClass="TextBoxCssMulti" runat="server" TextMode="MultiLine"></asp:TextBox>
                </div>
            </div>
            <div class="line">
              <%-- Bu divi Silme --%>
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
                                <asp:Label CssClass="label" runat="server">İşlem Türü: </asp:Label>
                            </div>
                            <div class="lineSagDiv"> 
                                <asp:Label ID="lblil" runat="server" Text='<%#Eval("islemturu") %>'></asp:Label>
                            </div>
                        </div><div class="line">
                            <div class="lineSolDiv">
                                <asp:Label CssClass="label" runat="server">Makbuz No: </asp:Label>
                            </div>
                            <div class="lineSagDiv">
                                <asp:Label ID="lblilce"  runat="server" Text='<%#Eval("makbuzno") %>'></asp:Label>

                            </div>
                        </div>
                        <div class="line">
                            <div class="lineSolDiv">
                                <asp:Label CssClass="label" runat="server">Gönderen: </asp:Label>
                            </div>
                            <div class="lineSagDiv">
                                <asp:Label ID="lbladresadi" runat="server" Text='<%#Eval("gonderen") %>'></asp:Label>
                            </div>
                        </div>
                        <div class="line">
                            <div class="lineSolDiv">
                                <asp:Label CssClass="label" runat="server">Alıcı: </asp:Label>
                            </div>
                            <div class="lineSagDiv">
                                <asp:Label ID="lbladres" runat="server" Text='<%#Eval("alici") %>'></asp:Label>
                            </div>
                        </div>
                        <div class="line">
                            <div class="lineSolDiv">
                                <asp:Label CssClass="label" runat="server">Tutar: </asp:Label>
                            </div>
                            <div class="lineSagDiv">
                                <asp:Label ID="lblaciklama" runat="server" Text='<%#Eval("tutar") %>'></asp:Label>
                            </div>
                        </div>
                        <div class="line">
                            <div class="lineSolDiv">
                                <asp:Label CssClass="label" runat="server">Tarih: </asp:Label>
                            </div>
                            <div class="lineSagDiv">
                                <asp:Label ID="Label1" runat="server" Text='<%#Eval("tarihsaat") %>'></asp:Label>
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
                    </div>
                </ItemTemplate>
            </asp:ListView>
        </div>
    </div>

</asp:Content>

