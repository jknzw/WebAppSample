<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ToDo.aspx.cs" Inherits="WebAppSample.ToDo" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>Vue ToDo List</title>
    <script src="https://cdn.jsdelivr.net/npm/vue/dist/vue.js"></script>
    <style>
        table {
            border: 2px solid #BBBBBB;
            border-collapse: collapse;
        }

        td {
            border: 1px solid #BBBBBB;
            text-align: center;
        }

        thead tr td {
            font-weight: bold;
        }

        .todo {
            text-align: left;
        }

        .completeTasks {
            background: #AAAAAA;
        }

        .checkbox input[type="checkbox"] {
            display: none;
        }

        .checkbox label {
            display:inline-block;
            color:#fff;
            background-color:#2780e3;
            padding:5px 10px;
        }

        .checkbox:checked + label {
            background-color:#000;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div id="app">
            <input type="text" v-model="addText" placeholder="ToDoを入力" />
            <button v-on:click="addToDo();" onclick="return false;">追加</button>
            <table>
                <thead>
                <tr>
                    <td></td>
                    <td>ID</td>
                    <td>ToDo</td>
                    <td>操作</td>
                </tr>
                </thead>
                <tbody>
                    <tr v-for="todo in list" v-bind:class="{'completeTasks' : todo.flag === false}">
                        <td class="checkbox">
                            <input type="checkbox" v-bind:id="'bar'+todo.id" @click="changeToDo(todo.id)" onclick="return false;" />
                            <label v-bind:for="'bar'+todo.id" v-if="todo.flag">未着手</label>
                            <label v-bind:for="'bar'+todo.id" v-else="todo.flag">完了</label>
                        </td>
                        <td>
                            <div v-bind:name="'id' + todo.id">{{ todo.id }}</div>
                        </td>
                        <td class="todo">
                            <div v-bind:name="'text' + todo.id">{{ todo.text }}</div>
                        </td>
                        <td>
                            <button @click="editToDo(todo.id)" v-if="todo.flag"  onclick="return false;">更新</button>
                            <button @click="deleteToDo(todo.id)"  onclick="return false;">削除</button>
                        </td>
                    </tr>
                </tbody>
            </table>
        </div>
    </form>
    <script src="js/ToDo.js"></script>
</body>
</html>
