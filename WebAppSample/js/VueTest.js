var app = new Vue({
    el: '#app',
    data: {
        addText: '',
        list: [],
        uniqueKey: 0,
    },
    methods: {
        addToDo() {
            if (this.addText) {
                this.list.unshift({
                    'text': this.addText,
                    'id': this.uniqueKey + 1,
                    'flag': true
                });
                this.addText = '';  //入力値初期化
                this.uniqueKey++;
            }
        },
        deleteToDo(id) {
            var deleteIndex = '';
            var check = confirm('本当に削除しますか？');
            if (check === true) {    //アラートでOKが押下されたら
                this.list.some(function (value, index) {
                    if (value.id === id) {
                        deleteIndex = index;
                    }
                });
                this.list.splice(deleteIndex, 1);
            }
        },
        editToDo(id) {
            var newText = window.prompt('以下内容で更新します。');
            if (newText === '') {
                alert('入力欄が空欄です。');
            } else if (newText !== null) {
                this.edit(id, newText);
            }
        },
        edit(id, text) {
            var editIndex = '';
            this.list.some(function (value, index) {
                if (value.id === id) {
                    editIndex = index;
                }
            });
            this.list[editIndex].text = text;
        },
        changeToDo(id) {
            var changeIndex = '';
            this.list.some(function (value, index) {
                if (value.id === id) {
                    changeIndex = index;
                }
            });
            this.list[changeIndex].flag = this.change(changeIndex);
        },
        change(changeIndex) {
            if (this.list[changeIndex].flag === true) {
                return false;
            } else {
                return true;
            }
        }
    }
});
