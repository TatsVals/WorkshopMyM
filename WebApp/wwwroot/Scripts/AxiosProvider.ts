
namespace App.AxiosProvider   {

    export const SaveProducts = (entity) => axios.post<DBEntity>("Products/Edit", entity).then(({ data }) => data);
    export const DeleteProducts = (id) => axios.delete<DBEntity>("Products/Grid?handler=Eliminar&id=" + id).then(({ data }) => data);

}




