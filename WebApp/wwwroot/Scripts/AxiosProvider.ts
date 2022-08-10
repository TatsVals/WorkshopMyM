﻿
namespace App.AxiosProvider   {

    export const SaveProducts = (entity) => axios.post<DBEntity>("Products/Edit", entity).then(({ data }) => data);
    export const DeleteProducts = (id) => axios.delete<DBEntity>("Products/Grid?handler=Eliminar&id=" + id).then(({ data }) => data);

    export const SaveRoles = (entity) => axios.post<DBEntity>("Roles/Edit", entity).then(({ data }) => data);
    export const DeleteRoles = (id) => axios.delete<DBEntity>("Roles/Grid?handler=Eliminar&id=" + id).then(({ data }) => data);

    export const SaveUsers = (entity) => axios.post<DBEntity>("Users/Edit", entity).then(({ data }) => data);
    export const DeleteUsers = (id) => axios.delete<DBEntity>("Users/Grid?handler=Eliminar&id=" + id).then(({ data }) => data);

    export const SavePermisos = (entity) => axios.post<DBEntity>("Permisos/Edit", entity).then(({ data }) => data);
    export const DeletePermisos = (id) => axios.delete<DBEntity>("Permisos/Grid?handler=Eliminar&id=" + id).then(({ data }) => data);

    export const Login = (entity) => axios.post<DBEntity>("Login", entity).then(({ data }) => data);
}




