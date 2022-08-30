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
                filename: 'Reporte Ingresos al Sistema',
                title: '',
                exportOptions: {
                    columns: [0, 1, 2]
                },
                className: 'btn-exportar-excel',
            },
            //'pdf',
            {
                extend: 'pdfHtml5',
                text: 'Exportar PDF',
                filename: 'Reporte Ingresos al Sistema',
                title: '',
                exportOptions: {
                    columns: [0, 1, 2]
                },
                className: 'btn-exportar-pdf',
            },
            //'print'
            {
                extend: 'print',
                title: '',
                exportOptions: {
                    columns: [0, 1, 2]
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