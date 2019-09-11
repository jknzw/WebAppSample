<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ToDo.aspx.cs" Inherits="WebAppSample.ToDo" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>Vue ToDo List</title>
    <script src="https://cdn.jsdelivr.net/npm/vue/dist/vue.js"></script>
    <style>
        table{
            border:2px solid #BBBBBB;
            border-collapse: collapse;
        }
        td{
            border: 1px solid #BBBBBB;
            text-align: center;
        }
        thead tr td {
            font-weight: bold;
        }
        .todo{
            text-align: left;
        }
        .completeTasks{
            background: #AAAAAA;
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
                <!-- 未着手時 start -->
                <tr v-for="todo in list" v-if="todo.flag === true">
                    <td>
                        <button @click="changeToDo(todo.id)" onclick="return false;">作業完了</button>
                    </td>
                    <td>
                        <div v-bind:name="'id' + todo.id">{{ todo.id }}</div>
                    </td>
                    <td class="todo">
                        <div v-bind:name="'text' + todo.id">{{ todo.text }}</div>
                        <!-- 0:未着手 -->
                        <div style="display:none;" v-bind:name="'status' + todo.id">0</div>
                    </td>
                    <td>
                        <button @click="deleteToDo(todo.id)"  onclick="return false;">削除</button>
                        <button @click="editToDo(todo.id)"  onclick="return false;">更新</button>
                    </td>
                </tr>
                <!-- 未着手時 end -->
                <!-- 作業完了時 start -->
                <tr v-for="todo in list" v-if="todo.flag === false" class="completeTasks">
                    <td>
                        <button @click="changeToDo(todo.id)" onclick="return false;">戻す</button>
                    </td>
                    <td>
                        <div v-bind:name="'id' + todo.id">{{ todo.id }}</div>
                    </td>
                    <td class="todo">
                        <div v-bind:name="'text' + todo.id">{{ todo.text }}</div>
                        <!-- 1:完了 -->
                        <div style="display:none;" v-bind:name="'status' + todo.id">1</div>
                    </td>
                    <td>
                        <button @click="deleteToDo(todo.id)" onclick="return false;">削除</button>
                    </td>
                </tr>
                <!-- 作業完了時 end -->
                </tbody>
            </table>
        </div>
    </form>
    <script src="js/ToDo.js"></script>
</body>
</html>
