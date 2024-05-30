using Microsoft.AspNetCore.Mvc;
using TarefasPlus.Mvc.Models;
using TarefasPlus.Repositorios.Http.Interfaces;
using static TarefasPlus.Mvc.Models.TarefaViewModel;
using static TarefasPlus.Mvc.Models.TarefaPaginacaoViewModel;
using AutoMapper;
using TarefasPlus.Repositorios.Http.Mensagens;

namespace TarefasPlus.Mvc.Controllers
{
    public class TarefasController : Controller
    {
        private readonly ITarefaRepositorio _tarefaRepositorio;
        private readonly IMapper _mapper;

        public TarefasController(ITarefaRepositorio tarefaRepositorio, IConfiguration configuracao, IMapper mapper)
        {
            _tarefaRepositorio = tarefaRepositorio;
            _mapper = mapper;
            _tarefaRepositorio.Caminho = configuracao.GetSection("Endpoints:TarefasApi:Path").Value.Trim();
        }

        //public async Task<ActionResult> Index()
        public ActionResult Index()
        {
            //return View(Mapear(await _tarefaRepositorio.Get(new TarefaQueryMensagem())));
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> GetGridData(IFormCollection campos)
        {
            var query = new TarefaQueryMensagem();

            query.RegistrosIgnorados = Convert.ToInt32(campos["start"]);
            query.RegistrosPorPagina = Convert.ToInt32(campos["length"]);
            query.Descricao = campos["search[value]"];

            var tarefaPaginacao = _mapper.Map<TarefaPaginacaoViewModel>(await _tarefaRepositorio.Get(query));

            return Json(new
            {
                draw = campos["draw"],
                recordsTotal = tarefaPaginacao.TotalRegistros,
                recordsFiltered = tarefaPaginacao.TotalRegistros,
                data = tarefaPaginacao.Tarefas
            });
        }


        public ActionResult Create()
        {
            return View(new TarefaViewModel());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(TarefaViewModel model)
        {
            try
            {
                await _tarefaRepositorio.Post(Mapear(model));

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        public async Task<ActionResult> Edit(int id)
        {
            return View(Mapear(await _tarefaRepositorio.Get(id)));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(TarefaViewModel model)
        {
            try
            {
                await _tarefaRepositorio.Put(Mapear(model), model.Id);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        public async Task<ActionResult> Delete(int id)
        {
            return View(Mapear(await _tarefaRepositorio.Get(id)));
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmation(int id)
        {
            try
            {
                await _tarefaRepositorio.Delete(id);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}