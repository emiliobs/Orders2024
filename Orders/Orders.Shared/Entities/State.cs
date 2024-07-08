﻿using Orders.Shared.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace Orders.Shared.Entities
{
    public class State : IEntityWithName
    {
        public int Id { get; set; }

        [Display(Name = "Departamento / Estado")]
        [MaxLength(100, ErrorMessage = "El Campo {0} no puede tener más de {1} caracteres.")]
        [Required(ErrorMessage = "El campo {0} es requerido.")]
        public string Name { get; set; } = null!;

        //Relation
        public int CountryId { get; set; }
        public Country? Country { get; set; }

        public ICollection<City> Cities { get; set; }

        [Display(Name = "Ciudades")]
        public int CityNumber => Cities == null || Cities.Count == 0 ? 0 : Cities.Count;
    }
}
