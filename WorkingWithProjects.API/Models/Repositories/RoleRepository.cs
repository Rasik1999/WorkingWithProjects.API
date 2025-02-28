﻿using System;
using System.Collections.Generic;
using System.Linq;
using WorkingWithProjects.DATA;

namespace WorkingWithProjects.API.Models
{
    public class RoleRepository : IRoleRepository
    {
        private readonly ContextDB _context;

        public RoleRepository(ContextDB context)
        {
            _context = context;
        }

        public Role AddRole(Role role)
        {
            var result = _context.Roles.Add(role).Entity;

            _context.SaveChanges();

            return result;
        }

        public Role DeleteRole(int roleId)
        {
            var foundedRole = _context.Roles.FirstOrDefault(e => e.RoleId == roleId);
            if (foundedRole == null) return null;

            var deletedRole = _context.Roles.Remove(foundedRole);
            _context.SaveChanges();

            return deletedRole.Entity;
        }

        public IEnumerable<Role> GetAllRoles()
        {
            return _context.Roles;
        }

        public Role GetRole(int roleId)
        {
            return _context.Roles.FirstOrDefault(x => x.RoleId == roleId);
        }

        public Role UpdateRole(Role role)
        {
            var foundedRole = _context.Roles.FirstOrDefault(e => e.RoleId == role.RoleId);

            if (foundedRole != null)
            {
                foundedRole.Name = role.Name;

                _context.SaveChanges();

                return foundedRole;
            }

            return null;
        }

        public bool CreateRelationship(int roleId, int kindId)
        {
            try
            {
                KindOfProject kind = _context.KindsOfProject.Where(x => x.KindOfProjectId == kindId).FirstOrDefault();
                Role role = _context.Roles.Where(x => x.RoleId == roleId).FirstOrDefault();

                role.KindOfProjectRoles.Add(new KindOfProjectRole() { KindId = kind.KindOfProjectId, RoleId = role.RoleId });

                _context.Roles.Update(role);

                _context.SaveChanges();
            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }
    }
}
