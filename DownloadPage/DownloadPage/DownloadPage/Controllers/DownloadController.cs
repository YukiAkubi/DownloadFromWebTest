using Microsoft.AspNetCore.Mvc;
using System;

namespace DownloadPage.Controllers;

public class DownloadController : Controller
{
    public IActionResult Index()
    {
        return View();
    }

    [HttpPost]
    public FileResult DownloadApk(string version)
    { 
        // バージョンに基づいてAPKファイルのパスを取得
        string filePath = GetApkFilePath(version);

        // ファイルが存在するか確認
        if (System.IO.File.Exists(filePath))
        {
            // ファイルをダウンロード
            return File(filePath, "application/vnd.android.package-archive", "YourApp.apk");
        }
        else
        {
            // ファイルが存在しない場合はエラーを表示
            throw new Exception("ダウンロード失敗");
        }
    }

    private string GetApkFilePath(string version)
    {
        // バージョンに基づいてAPKファイルのパスを生成
        // このメソッドを実際のファイルパス生成ロジックに置き換える必要があります
        // 例: return Path.Combine(Server.MapPath("~/ApkFiles"), $"YourApp_{version}.apk");
        return $@"c:\{version.Replace(".", string.Empty)}\App.apk"; // 実際のファイルパス生成ロジックに合わせて適切なパスを返す
    }
}
