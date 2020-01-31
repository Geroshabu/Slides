# Microsoft Graph API を体験しよう

---

## 作るアプリ

(画像はる)

--

## 開発環境等

* Visual Studio 2019
* C# 8.0
* WPF (.Net Core)

--

## 使うAPI

* サインインユーザの取得
    * `GET /v1.0/me`
    * https://docs.microsoft.com/ja-jp/graph/api/user-get?view=graph-rest-1.0

--

## 作るアプリのクラス図

サンプルアプリなのにしっかり設計するよ！


---

## 流れ

0. データの用意
1. アプリの登録
2. アプリの作成
    1. アクセストークンの取得
    2. APIを叩く!!!

---

## データの用意

架空のユーザー
* Display Name : Freddie
* Mobile Phone : +81 9012345678
* 役職 : 係長

--

Azureポータルにアクセス

https://portal.azure.com/

--

1. 「Azure Active Directory」 をクリック
2. ディレクトリの作成
3. ユーザー「Freddie」追加

---

## アプリの登録

--

Azureポータルでアプリの登録

* Azure Active Directoryで「アプリの登録」から
* 今回は、任意の組織・個人アカウント
* リダイレクトURI : `https://login.microsoftonline.com /common/oauth2/nativeclient`

---

## アプリの作成

Let's enjoy coding!!

--

まずは画面を作ろう

(Graph API とは関係ない作業)

--

### 余談

* .Net Standard/Core のプロジェクトってシンプルでいいよね
* [これは「SDKスタイル」というらしい](https://docs.microsoft.com/ja-jp/nuget/resources/check-project-format)
* SDKスタイルは .Net Framework でも使える

(非SDKスタイルのままだと後で[ハマりました](http://kuttsun.blogspot.com/2018/08/dll.html))

---

## アクセストークンの取得

--

Graph API を利用するにはアクセストークンが必要

```
GET /v1.0/me
Host: https://graph.microsoft.com
Authorization: Bearer eyJ0eXAiOiJKV1QiLCJhbGciOiJSUzI1N...(省略)
```

--

### アクセストークンの取得の手順

OAuth 2.0 で認証すると取得できる
([認証フロー](https://docs.microsoft.com/ja-jp/azure/active-directory/develop/v2-oauth2-auth-code-flow))

ちょっと見てみよう！うっ...むずかしそう!!!

--

### Microsoft Authentication Library (MSAL)

* 難解な認証フローを超簡単にできる！
* 様々な言語向けに (C#, Python, JS, ...)
* Microsoft が作ってる
* C# (というか.Net) 向けのものはこれ : [Microsoft.Identity.Client](https://www.nuget.org/packages/Microsoft.Identity.Client)

--

早速 MSAL を導入してみよう！

--

* 認証にはアプリケーションIDが必要
* アプリの概要ページに書いてある
* 外部に漏れないよう厳重に管理すること!!!
* ソースコード中に書くのも避けること (でも今回は書いちゃう)

--

### 使うメソッド

* `IPublicClientApplication.AcquireTokenInteractive`

    サインイン画面を出して対話的に認証する。

* `IPublicClientApplication.AcquireTokenSilent`

    すでにサインイン済みのアカウントがある場合はこちら。
    サインイン画面を出す必要がある時(サインイン済みのアカウントが無い・トークンの期限切れ)は
    `MsalUiRequiredException` が出る。

--

### ここまで試してみよう！

* さっき作った「Freddie」のIDとパスワードでサインイン
* 初回アクセスなのでパスワードの変更を求められる (今回これがいちばん厄介)

---

## APIを叩く!!!
