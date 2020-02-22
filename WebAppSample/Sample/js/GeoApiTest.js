
// 現在地取得処理
function getPosition() {
    // 現在地を取得
    navigator.geolocation.getCurrentPosition(
        // 取得成功した場合
        function (position) {
            var latitude = position.coords.latitude;
            var longitude = position.coords.longitude;
            setAddress(latitude, longitude);

            alert("緯度:" + position.coords.latitude + ",経度" + position.coords.longitude);
        },
        // 取得失敗した場合
        function (error) {
            switch (error.code) {
                case 1: //PERMISSION_DENIED
                    alert("位置情報の利用が許可されていません");
                    break;
                case 2: //POSITION_UNAVAILABLE
                    alert("現在位置が取得できませんでした");
                    break;
                case 3: //TIMEOUT
                    alert("タイムアウトになりました");
                    break;
                default:
                    alert("その他のエラー(エラーコード:" + error.code + ")");
                    break;
            }
        }
    );
}

/**
 * 
 * @param {any} latitude 緯度
 * @param {any} longitude 経度
 */
function setAddress(latitude, longitude) {
    var requestAjax = function (endpoint, callback) {
        var xhr = new XMLHttpRequest();
        xhr.onreadystatechange = function () {
            if (this.readyState == 4 && this.status == 200) {
                callback(this.response);
            }
        };
        xhr.responseType = 'json';
        xhr.open('GET', endpoint, true);
        xhr.send();
    };

    // 東京駅の緯度経度
    var apiKey = 'dj00aiZpPUlXWjNmSVZSU3o4dSZzPWNvbnN1bWVyc2VjcmV0Jng9OTU-';
    var requestURL = 'https://map.yahooapis.jp/geoapi/V1/reverseGeoCoder?';
    requestURL += '&lat=' + latitude + '&lon=' + longitude;
    requestURL += '&appid=' + apiKey;
    //requestAjax(requestURL, function (response) {
    //    // callback function
    //    if (response.error_message) {
    //        console.log(response.error_message);
    //    } else {
    //        var formattedAddress = response.results[0]['formatted_address'];
    //        // 住所は「日本、〒100-0005 東京都千代田区丸の内一丁目」の形式
    //        var data = formattedAddress.split(' ');
    //        if (data[1]) {
    //            // id=addressに住所を設定する
    //            document.getElementById('address').value = data[1];
    //        }
    //    }
    //});


    HTML_Load(requestURL,'address');

}

var xmlhttp;
function HTML_Load(url, replace) {
    // Httpリクエスを作る
    xmlhttp = new XMLHttpRequest();
    
    xmlhttp.open("GET", url, true);
    xmlhttp.onreadystatechange = function () {
        //とれた場合Idにそって入れ替え
        if (xmlhttp.readyState == 4 && xmlhttp.status == 200) {
            var data = xmlhttp.responseText;
            var elem = document.getElementById(replace);
            elem.value = data;
            return data;
        }
    }
    xmlhttp.send(null);
}

// https://developer.yahoo.co.jp/webapi/map/openlocalplatform/v1/reversegeocoder.html
// https://map.yahooapis.jp/geoapi/V1/reverseGeoCoder?&appid=dj00aiZpPUlXWjNmSVZSU3o4dSZzPWNvbnN1bWVyc2VjcmV0Jng9OTU-&lat=xxx&lon=xxx
// https://re-engines.com/2018/03/19/reverse-geocoding/
// https://qiita.com/akkey2475/items/81f4f94f17bfe5c7ce42