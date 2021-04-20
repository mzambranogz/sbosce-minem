﻿$(document).ready(() => {
    cargarExcel()
})

var cargarExcel = () => {
    let url = `${baseUrl}Resultado/ListaResultado`;
    fetch(url).then(r => r.json()).then(j => {
        if (j == null) return
        let contenido = ``, cont = 0;
        if (j.length > 0) {
            contenido = j.map((x, y) => {
                let colNro = `<td class="text-left" data-encabezado="Código">${++cont}</td>`;
                let colNombres = `<td class="text-left" data-encabezado="Descripción">Resultado N°${x.ID_RESULTADO}</td>`;
                let colFecha = `<td class="text-left" data-encabezado="Descripción">${x.FECHA_REGISTRO}</td>`;
                //let btnCambiarEstado = `<a class="dropdown-item estilo-01 btnCambiarEstado" href="#" data-id="${x.ID_REQUERIMIENTO}" data-estado="${x.FLAG_ESTADO}"><i class="fas fa-edit mr-1"></i>Eliminar</a>`;
                let btnEditar = `<a class="dropdown-item estilo-01 btnEditar" href="${baseUrl}Resultado/VerResultado/${x.ID_RESULTADO}" data-id="${x.ID_RESULTADO}"><i class="fas fa-edit mr-1"></i>Ver resultado</a>`;
                //let colOpciones = `<td class="text-center" data-encabezado="Gestión"><div class="btn-group w-100"><a class="btn btn-sm bg-success text-white w-100 dropdown-toggle" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false" tabindex="0">Gestionar</a><div class="dropdown-menu">${btnCambiarEstado}${btnEditar}</div></div></td>`;
                let colOpciones = `<td class="text-center" data-encabezado="Gestión"><div class="btn-group w-100"><a class="btn btn-sm bg-success text-white w-100 dropdown-toggle" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false" tabindex="0">Gestionar</a><div class="dropdown-menu">${btnEditar}</div></div></td>`;
                let fila = `<tr>${colNro}${colNombres}${colFecha}${colOpciones}</tr>`;
                return fila;
            }).join('');;
        }
        $('#tbl-excel').find('tbody').html(contenido)
    });
}