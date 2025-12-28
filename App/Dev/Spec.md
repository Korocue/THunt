App/Dev/Spec.md

# ファイル保存場所
保存場所をAppDataとする設定です。確認してください。

## ボード設定用jsonのスキーマ
{
  "schema": 1,
  "appVersion": "1.b3",
  "height": 10,
  "width": 10,
  "bombs": 15,
  "treasures": 5
}

## Persistence / Settings
- Board settings type: BoardSettings
- File name: BoardSettings.json
- Storage location: %APPDATA%\T-Hunt\ (Environment.SpecialFolder.ApplicationData)
- Create directory if missing.
- Load behavior:
  - If file missing: use defaults (optionally write defaults on first run).
  - If file invalid: keep app running with defaults and rename old file to *.broken.json
- Save behavior: write to temp file then replace (atomic-ish).
- Never write user settings into repository folders or bin/Debug.