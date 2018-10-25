using System;
using DDD.EDT.Domain;

namespace DDD.EDT.ApplicationCore
{
    public class ReservationService
    {
        private readonly IMasterpieceRepository _masterpieceRepository;
        private readonly IOwnerFacade _ownerFacade;

        public ReservationService(IMasterpieceRepository masterpieceRepository, IOwnerFacade ownerFacade)
        {
            _masterpieceRepository = masterpieceRepository;
            _ownerFacade = ownerFacade;
        }

        public ReservationResult Reserve(Guid masterpieceId, Guid ownerId, Guid productId)
        {
            var masterpiece = _masterpieceRepository.GetMasterpiece(masterpieceId);
            var product = new ProductSnapshot(productId);
            var owner = _ownerFacade.GetOwner(ownerId);

            if (!masterpiece.IsReservedBySomeoneBesides(owner)
                && masterpiece.IsProductAvailable(product))
            {
                masterpiece.Reserve(owner, product); // event
            }
            else
            {
                return new ReservationResult();
            }

            _masterpieceRepository.Save(masterpiece);

            return new ReservationResult();
        }
    }
}