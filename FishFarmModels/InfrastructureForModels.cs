using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;


namespace FishFarm.Models
{
    public enum TankShape
    {
        [Display(Name = "UnKnown")]
        UnKnown,
        [Display(Name ="Rectangle")]
        Rectangle,
        [Display(Name ="Square")]
        Square,
        [Display(Name ="Circular")]
        Circular,
        [Display(Name ="Oval")]
        Oval
    }

    public enum InOutType
    {
        [Display(Name ="Batch In")]
        BatchIn,
        [Display(Name ="Batch Out")]
        BatchOut,
        [Display(Name ="Internal Transportation")]
        InternalTransport
    }

    public enum SelectionOptions
    {
        Passive = -1,
        All,
        Active,
        
    }
}
