﻿<%@ Page Title="Dava" Language="C#" MasterPageFile="~/AnaSayfaMaster.master" AutoEventWireup="true" CodeFile="dava.aspx.cs" Inherits="Kullanici_dava" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
    <link href="/CssDosyalari/davea.css" rel="stylesheet"/>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <div class="pageDisDiv">
        <div class="ustDiv">
            <div class="lineOrta" style="border-bottom: solid silver thin; margin-bottom: 2%;">
                <asp:Label CssClass="label" runat="server" Text="Yeni Dava" Font-Size="200%">Yeni Dava Oluştur</asp:Label>
            </div>
            <div class="line">
                <div class="lineSolDiv">
                    <asp:Label CssClass="label" runat="server">Dava Türü:</asp:Label>
                </div>
                <div class="lineSagDiv">
                    <asp:DropDownList ID="drpDavaTuru" runat="server" CssClass="drplist" AutoPostBack="true" OnSelectedIndexChanged="drpDavaTuru_SelectedIndexChanged">
                    </asp:DropDownList>
                </div>
            </div>
            <div class="line">
                <div class="lineSolDiv">
                    <asp:Label CssClass="label" runat="server">Dava No:</asp:Label>
                </div>
                <div class="lineSagDiv">
                    <asp:TextBox ID="txtDavaNo" CssClass="TexBoxCss" runat="server" MaxLength="50"></asp:TextBox>
                </div>
            </div>

            <div class="line">
                <div class="lineSolDiv">
                    <asp:Label CssClass="label" runat="server">Dava Aktif:</asp:Label>
                </div>
                <div class="lineSagDiv">
                    <asp:CheckBox ID="chckDavaAktif" runat="server" Checked="True"/>
                </div>
            </div>
            <div class="line">
                <div class="lineSolDiv">
                    <asp:Label CssClass="label" runat="server">Mahkeme:</asp:Label>
                </div>
                <div class="lineSagDiv">
                    <asp:DropDownList ID="drpMahkeme" runat="server" CssClass="drplist" AutoPostBack="true">
                    </asp:DropDownList>
                </div>
            </div>
            <div class="line">
                <div class="lineSolDiv">
                    <asp:Label CssClass="label" runat="server">Taraf Türü:</asp:Label>
                </div>
                <div class="lineSagDiv">
                    <asp:DropDownList ID="drpTarafTur" runat="server" CssClass="drplist" AutoPostBack="true"> </asp:DropDownList>
                </div>
            </div>
            
            <div class="line">
                <div class="lineSolDiv">
                    <asp:Label CssClass="label" runat="server">Taraf Adı:</asp:Label>
                </div>
                <div class="lineSagDiv">
                    <asp:DropDownList ID="drpKisiAdiSoyadi" runat="server" CssClass="drplist" AutoPostBack="true"> </asp:DropDownList>
                </div>
            </div>
            

            <div class="line">
                <div class="lineSolDiv">
                    <asp:Label CssClass="label" runat="server">Duruşma Tarihi:</asp:Label>
                </div>
                <div class="lineSagDiv">
                    <asp:TextBox ID="txtDurusmaTarihi" CssClass="TexBoxCss" runat="server" TextMode="Date"></asp:TextBox>
                </div>
            </div>
            <div class="line">
                <div class="lineSolDiv">
                    <asp:Label CssClass="label" runat="server">Dava Hakkında:</asp:Label>
                </div>
                <div class="lineSagDiv">
                    <asp:TextBox ID="txtDavaAciklama" CssClass="TextBoxCssMulti" runat="server" MaxLength="250" TextMode="MultiLine"></asp:TextBox>
                </div>
            </div>
            <div class="line">
                <div class="lineSolDiv">
                    <asp:Label CssClass="label" runat="server">Duruşma Hakkında:</asp:Label>
                </div>
                <div class="lineSagDiv">
                    <asp:TextBox ID="txtDurusmaAciklama" CssClass="TextBoxCssMulti" runat="server" MaxLength="250" TextMode="MultiLine"></asp:TextBox>
                </div>
            </div>
            <div class="line">
                <div class="lineSolDiv">
                    <asp:Label CssClass="label" runat="server">Duruşma Aktif:</asp:Label>
                </div>
                <div class="lineSagDiv">
                    <asp:CheckBox ID="chckDurusmaAktif" runat="server" Checked="True"/>
                </div>
            </div>
            <div class="line">
                <%--Bu divi Silme Duruşma Aktifmi Satırıını sola yaslamak için yapıldı--%>
            </div>
            <div class="lineOrta">
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtDavaNo" ErrorMessage="Dava Numarası Giriniz" SetFocusOnError="True" Display="None"></asp:RequiredFieldValidator>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtDurusmaTarihi" ErrorMessage="Geçerli Bir Tarih Giriniz" SetFocusOnError="True" Display="None"></asp:RequiredFieldValidator>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtDavaAciklama" ErrorMessage="Dava Hakkında Açıklama Giriniz" SetFocusOnError="True" Display="None"></asp:RequiredFieldValidator>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtDurusmaAciklama" ErrorMessage="Duruşma Hakkında Açıklama Giriniz" SetFocusOnError="True" Display="None"></asp:RequiredFieldValidator>
                <asp:ValidationSummary ID="ValidationSummary1" runat="server" ForeColor="Red" CssClass="validationSummary"/>
            </div>
            <div class="lineOrta">
                <button runat="server" id="btnKaydet" class="button" OnServerClick="btnKaydet_Click" Text="Kaydet">
                    <i class="fa fa-save fa-2x"></i> Kaydet
                </button>
            </div>

        </div>
        <div class="altDiv">
            <asp:ListView ID="list2" runat="server">
                <ItemTemplate>
                    <div class="ListeDiv">
                        <div class="line">
                            <div class="lineSolDiv">
                                <asp:Label CssClass="label" runat="server">Dava Türü:</asp:Label>
                            </div>
                            <div class="lineSagDiv">
                                <asp:Label ID="lblDavaTuru" runat="server" Text='<%#Eval("davaturad") %>'></asp:Label>
                            </div>
                        </div>
                        <div class="line">
                            <div class="lineSolDiv">
                                <asp:Label CssClass="label" runat="server">Dava No:</asp:Label>
                            </div>
                            <div class="lineSagDiv">
                                <asp:Label ID="lblDavaNo" runat="server" Text='<%#Eval("davano") %>'></asp:Label>
                            </div>
                        </div>

                        <div class="line">
                            <div class="lineSolDiv">
                                <asp:Label CssClass="label" runat="server">Dava Aktif:</asp:Label>
                            </div>
                            <div class="lineSagDiv">
                                <asp:Label ID="lblDavaAktif" runat="server" Text='<%#Eval("davaaktif") %>'></asp:Label>

                            </div>
                        </div>
                        <div class="line">
                            <div class="lineSolDiv">
                                <asp:Label CssClass="label" runat="server">Mahkeme:</asp:Label>
                            </div>
                            <div class="lineSagDiv">
                                <asp:Label ID="lblMahkeme" runat="server" Text='<%#Eval("mahkemead") %>'></asp:Label>
                            </div>
                        </div>
                        <div class="line">
                            <div class="lineSolDiv">
                                <asp:Label CssClass="label" runat="server">Taraf Türü:</asp:Label>
                            </div>
                            <div class="lineSagDiv">
                                <asp:Label ID="lblTarafTuru" runat="server" Text='<%#Eval("davatarafturad") %>'></asp:Label>
                            </div>
                        </div>
                        <div class="line">
                            <div class="lineSolDiv">
                                <asp:Label CssClass="label" runat="server">Taraf Adı:</asp:Label>
                            </div>
                            <div class="lineSagDiv">
                                <asp:Label ID="Label1" runat="server" Text='<%#Eval("ad") %>'></asp:Label>
                            </div>
                        </div> 
                        <div class="line">
                            <div class="lineSolDiv">
                                <asp:Label CssClass="label" runat="server">Dava Hakkında:</asp:Label>
                            </div>
                            <div class="lineSagDiv">
                                <asp:Label ID="lblDavaAciklama" runat="server" Text='<%#Eval("davaaciklama") %>'></asp:Label>
                            </div>
                        </div>
                        <div class="line">
                            <div class="lineSolDiv">
                                <asp:Label CssClass="label" runat="server">Duruşma Tarihi:</asp:Label>
                            </div>
                            <div class="lineSagDiv">
                                <asp:Label ID="lblDurusmaTarihi" runat="server" Text='<%#Eval("tarihsaat") %>'></asp:Label>
                            </div>
                        </div>
                      
                        <div class="line">
                            <div class="lineSolDiv">
                                <asp:Label CssClass="label" runat="server">Duruşma Hakkında:</asp:Label>
                            </div>
                            <div class="lineSagDiv">
                                <asp:Label ID="lblDurusmaAciklama" runat="server" Text='<%#Eval("aciklama") %>'></asp:Label>
                            </div>
                        </div>
                        <div class="line">
                            <div class="lineSolDiv">
                                <asp:Label CssClass="label" runat="server">Duruşma Aktif:</asp:Label>
                            </div>
                            <div class="lineSagDiv">
                                <asp:Label ID="lbldurusmaAktif" runat="server" Text='<%#Eval("aktif") %>'></asp:Label>
                            </div>
                        </div>
                        <div class="line">
                            <%--Bu divi Silme Duruşma Aktifmi Satırıını sola yaslamak için yapıldı--%>
                        </div>
                    </div>
                </ItemTemplate>
            </asp:ListView>
        </div>
    </div>
</asp:Content>