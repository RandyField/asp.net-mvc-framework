<script src="1.js"></script>
<script src="2.js"></script>
<script src="3.js"></script>
<script src="4.js"></script>
<script src="5.js"></script>
<script src="6.js"></script>
<script src="js/require.js"></script>
<script src="js/require.js" defer async="true" ></script>
//async属性表明这个文件需要异步加载，避免网页失去响应。
//IE不支持这个属性，只支持defer，所以把defer也写上。

//加载require.js以后，下一步就要加载我们自己的代码了。
//假定我们自己的代码文件是main.js，也放在js目录下面。

<script src="js/require.js" data-main="js/main"></script>
//data-main属性的作用是，指定网页程序的主模块。
//在上例中，就是js目录下面的main.js，这个文件会第一个被require.js加载。
//由于require.js默认的文件后缀名是js，所以可以把main.js简写成main。


require(['moduleA', 'moduleB', 'moduleC'], function (moduleA, moduleB, moduleC){

    　　　　// some code here
    
    　　});

    // require()函数接受两个参数。第一个参数是一个数组，表示所依赖的模块，
    //上例就是['moduleA', 'moduleB', 'moduleC']，即主模块依赖这三个模块；
    //第二个参数是一个回调函数，当前面指定的模块都加载成功后，它将被调用。
    //加载的模块会以参数形式传入该函数，从而在回调函数内部就可以使用这些模块。