using System.Net.NetworkInformation;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;

using Radzen;
using Web_Stencill_Lifetime.Data;
using Web_Stencill_Lifetime.Model;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
SqlContect.conStr = builder.Configuration["ConnectionStrings:oracle_conn"];
SqlContectDX26.conStr = builder.Configuration["ConnectionStrings:oracle_connDX26"];
builder.Services.AddSignalR();
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddScoped<ObjStencil>();
builder.Services.AddScoped<GetData>();
builder.Services.AddScoped<SqlContect>();
builder.Services.AddScoped<SqlContectDX26>();
builder.Services.AddScoped<SqlData>();
builder.Services.AddScoped<DialogService>();
builder.Services.AddScoped<NotificationService>();
builder.Services.AddScoped<TooltipService>();
builder.Services.AddScoped<ContextMenuService>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
	app.UseExceptionHandler("/Error");
	// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
	app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
