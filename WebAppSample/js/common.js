var submitflg = false;

// 二重送信チェック
function submitCheck() {
    if (submitflg) {
        return false;
    } 

    submitflg = true;

    setTimeout(
        function () {
            submitflg = false;
        }, 3000);

    return true;
}
