function endCheck(obj) {
    // ポップアップ確認
    var text = obj.value;
    if (text === 'おわる') {
        if (!confirm("おわりますか？")) {
            return false;
        }
    }

    // 二重送信チェック
    if (!submitCheck()) {
        return false;
    }
    return true;
}
