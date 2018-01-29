using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace web
{
    public class Startup
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="configuration"></param>
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }


        /// <summary>
        /// 而ConfigureServices方法在Configure方法前调用，它是一个可选的方法，(应用程序运行时将服务添加到容器中)
        /// 可在configureServices依赖注入接口或一些全局的框架，比如EntityFramework、MVC等。
        /// </summary>
        /// <param name="services"></param>
        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            //mvc框架实现自己的添加方法(将MVC的服务添加到容器中)
            services.AddMvc();

            //IFoo - 接口
            //Foo - 实现接口
            services.AddTransient<IFoo, Foo>(); //将接口和实现注入至容器


            //// Add framework services.
            //services.AddDbContext<ApplicationDbContext>(options =>
            //    options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            //services.AddIdentity<ApplicationUser, IdentityRole>()
            //    .AddEntityFrameworkStores<ApplicationDbContext>()
            //    .AddDefaultTokenProviders();

        }

        /// <summary>
        /// Configure方法用于每次http请求的处理，比如后面要讲的中间件(Middleware)，
        /// 就是在configure方法中配置。
        /// http处理管道配置和一些系统配置,参数如下：
        /// </summary>
        /// <param name="app">用于构建应用请求管道。通过IApplicationBuilder下的run方法传入管道处理方法。这是最常用方法，对于一个真实环境的应用基本上都需要比如权限验证、跨域、异常处理等。</param>
        /// <param name="env">用于访问应用程序的特殊属性，比如applicationName,applicationVersio。</param>
        /// <param name="logger">提供创建日志的接口，可以选用已经实现接口的类或自行实现此接口,下面代码使用最简单的控制台作为日志输出。</param>
        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory logger)
        {
            //Middleware 功能描述
            //Authentication 提供权限支持
            //CORS 跨域的配置
            //Routing 配置http请求路由
            //Session 管理用户会话
            //Static Files    提供对静态文件的浏览

            //在configure方法中使用IApplicationBuilder对象的Run、Map、Use方法传入匿名委托(delegate)

            #region http请求拦截 依赖注入 IApplicationBuilder.Run

            ////如果想在每次Http请求后都使用IFoo的GetFoo()方法来处理
            ////可以在Configure方法中注册函数，在注册过程中由于使用了依赖注入(DI)
            //app.Run((context) =>
            //{
            //    var str = context.RequestServices.GetRequiredService<IFoo>().GetFoo();
            //    return context.Response.WriteAsync(str);
            //});
            ////调用IApplicationBuilder.Run方法注册处理函数。拦截每个http请求，输出调用IFoo的GetFoo()方法。

            //app.Use((context, next) =>
            //{
            //    context.Response.WriteAsync("ok");
            //    return next();
            //});
            //app.Use((context, next) =>
            //{
            //    return context.Response.WriteAsync("ok");
            //});

            ////含有两个参数pathMatche和configuration，通过请求的url地址匹配相应的configuration。
            //app.Map("/admin", builder1 =>
            //{
            //    builder1.Use((context, next) => context.Response.WriteAsync("admin"));
            //});

            #endregion

            #region 访问应用程序的特殊属性 获取配置文件eg

            //通过IHostingEnvironment对象下的属性可以在构造中实现配置工作。

            //比如获取当前根路径找到配置json文件地址，然后ConfigurationBuilder初始化配置文件，
            //最后可以通过GetSection()方法获取配置文件。
            var builder = new ConfigurationBuilder()
                            .SetBasePath(env.ContentRootPath)
                             .AddJsonFile("appsettings.json");
            var configuration = builder.Build();
            var connStr = configuration.GetSection("Data:DefaultConnection:ConnectionString").Value;

            #endregion

            #region 提供 创建日志 的接口
 
            var log = logger.CreateLogger("default");
            logger.AddConsole();
            log.LogInformation("start configure");

            #endregion


            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            //允许应用程序提供静态资源
            app.UseStaticFiles();

            //将MVC添加到管道并允许配置路由
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }





    public interface IFoo
    {
        string GetFoo();
    }

    public class Foo : IFoo
    {
        public string GetFoo()
        {
            return "Hello world";
        }
    }
}
