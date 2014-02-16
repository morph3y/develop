using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Contracts.Business;
using Framework.Common;

namespace Web.Infrastructure.Grid
{
    internal sealed class Grid
    {
        private Type EntityType { get; set; }
        private List<String> Columns { get; set; }
        private IEnumerable GridData { get; set; }
        private String GridId { get; set; }

        private UrlHelper _urlHelper;
        private UrlHelper UrlHelper
        {
            get { return _urlHelper ?? (_urlHelper = new UrlHelper(HttpContext.Current.Request.RequestContext)); }
        }

        private ViewDataDictionary _viewData;
        private ViewDataDictionary ViewData
        {
            get { return _viewData ?? (_viewData = new ViewDataDictionary()); }
        }

        private IObjectService _objectService;
        public IObjectService ObjectService
        {
            get { return _objectService ?? (_objectService = ApplicationEnvironment.Resolve<IObjectService>()); }
        }

        public Grid(Type entity, List<String> columns, IEnumerable data = null)
        {
            if (columns == null || columns.Count == 0)
            {
                throw new ArgumentException("There was no columns specified!");
            }

            EntityType = entity;
            Columns = columns;
            GridData = data;

            GridId = entity.Name + "_" + Guid.NewGuid();
        }

        public String Render()
        {
            EnsureDataLoaded();
            return GetGridHtml();
        }

        private String GetGridHtml()
        {
            var sb = new StringBuilder();
            sb.Append("<div class='gridContainer'><div class='gridHeader'><div class='gridTitle'>" + EntityType.Name + " List</div></div>");
            sb.Append("<div id='" + GridId + "' class='grid'><table>");

            RenderGridHeaders(sb);

            RenderGridBody(sb);

            sb.Append("</table></div>");
            sb.Append("<div class='gridFooter'></div></div>");
            sb.Append(Assets.Assets.Scripts.Components.Grid.Render(UrlHelper));
            sb.Append("<script type='text/javascript'>System.Grid.init('" + GridId + "');</script>");
            return sb.ToString();
        }

        private void RenderGridBody(StringBuilder sb)
        {
            foreach (var record in GridData)
            {
                ViewData.Model = record;
                sb.Append("<tr>");
                sb.Append("<td class='cell options'>" +
                    "<span class='option view ui-icon ui-icon-folder-open' data-url='" + 
                    UrlHelper.Action("RedirectToEntityController", "Grid", 
                        new RouteValueDictionary
                            {
                                { "actionName", "View" }, { "entityName", EntityType.Name }, { "entityId", ViewData.Eval("Id") }
                            }) + "'></span>" +
                          "<span class='option edit ui-icon ui-icon-wrench' data-url='" +
                          UrlHelper.Action("RedirectToEntityController", "Grid",
                        new RouteValueDictionary
                            {
                                { "actionName", "Edit" }, { "entityName", EntityType.Name }, { "entityId", ViewData.Eval("Id") }
                            })
                          +"'></span>" +
                          "<span class='option delete ui-icon ui-icon-closethick' data-url='"+
                          UrlHelper.Action("RedirectToEntityController", "Grid",
                        new RouteValueDictionary
                            {
                                { "actionName", "Delete" }, { "entityName", EntityType.Name }, { "entityId", ViewData.Eval("Id") }
                            })
                          +"'></span></td>");
                foreach (var property in Columns)
                {
                    sb.Append("<td class='cell'>" + ViewData.Eval(property) + "</td>");
                }
                sb.Append("</tr>");
            }
        }

        private void RenderGridHeaders(StringBuilder sb)
        {
            sb.Append("<tr class='headers'><td>Options</td>");
            foreach (var column in Columns)
            {
                sb.Append("<td>" + column + "</td>");
            }
            sb.Append("</tr>");
        }

        private void EnsureDataLoaded()
        {
            if (GridData == null)
            {
                GridData = ObjectService.GetCollection(EntityType, 5);
            }
        }
    }
}