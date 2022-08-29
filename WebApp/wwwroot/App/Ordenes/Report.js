$(document).ready(function () {

    $('#GridView').DataTable({
        language: {
            url: "https://cdn.datatables.net/plug-ins/1.11.5/i18n/es-ES.json"
        },
        dom: 'Bfrtip',
        buttons: [
            //'excel',
            {
                extend: 'excelHtml5',
                text: 'Exportar Excel',
                filename: 'Reporte Empleados',
                title: '',
                exportOptions: {
                    columns: [ 1, 2, 3, 4, 5, 6, 7, 8, 9, 10]
                },
                className: 'btn-exportar-excel',
            },
            //'pdf',
            {
                extend: 'pdfHtml5',
                text: 'Exportar PDF',
                filename: 'Reporte Empleados',
                title: '',
                exportOptions: {
                    columns: [1, 2, 3, 4, 5, 6, 7, 8, 9, 10]
                },
                className: 'btn-exportar-pdf',
            },
            //'print'
            {
                extend: 'print',
                title: '',
                exportOptions: {
                    columns: [1, 2, 3, 4, 5, 6, 7, 8, 9, 10]
                },
                className: 'btn-exportar-print'



            },
            //extra
            'pageLength'
        ],



        //extra
        //searching: false
    });





});